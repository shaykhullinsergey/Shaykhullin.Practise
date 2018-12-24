using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shelter;

namespace Practice
{
	[DataContract]
	public class TaskCompleteViewModel
	{
		[DataMember(Name = "lectureId")]
		public int LectureId { get; set; }

		public async Task<TaskResultViewModel> Complete(IServiceProvider provider, string session)
		{
			var profile = await provider.GetRequiredService<IProfileService>()
				.FirstAsync(x => x.Session == session);
			
			var lecture = await provider.GetRequiredService<ILectureService>()
				.FirstOrDefaultAsync(l => l.Id == LectureId);
			
			var nextLecture = await provider.GetRequiredService<ILectureService>()
				.OrderBy(x => x.Order)
				.FirstOrDefaultAsync(x => x.Order > lecture.Order);

			if (nextLecture != null)
			{
				var alreadyAdded = await provider.GetRequiredService<IQuizService>()
					.AnyAsync(x => x.Profile == profile && x.Lecture == nextLecture);

				if (!alreadyAdded)
				{
					await provider.GetRequiredService<IQuizService>()
						.Add(new Quiz
						{
							Profile = profile, Lecture = nextLecture
						});
				}
			}

			return new TaskResultViewModel
			{
				Success = true
			};
		}
	}

	[DataContract]
	public class TaskResultViewModel
	{
		[DataMember(Name = "success")]
		public bool Success { get; set; }
	}
}