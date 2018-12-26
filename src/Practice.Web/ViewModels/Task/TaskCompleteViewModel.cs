using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

			var quizResult = lecture.Quizzes.FirstOrDefault(q => q.Profile == profile);

			if (quizResult != null)
			{
				quizResult.Result = 5;
			}
			
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
				Results = Enumerable.Repeat(true, 5).ToList()
			};
		}
	}

	[DataContract]
	public class TaskResultViewModel
	{
		[DataMember(Name = "results")]
		public ICollection<bool> Results { get; set; }
	}
}