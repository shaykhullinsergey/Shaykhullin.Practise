using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using Shelter;

namespace Practice
{
	public class CreateProfileRequestViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		[DataMember(Name = "group")]
		public string Group { get; set; }

		public async Task<CreateProfileResponseViewModel> Create(IServiceProvider provider)
		{
			var profile = new Profile
			{
				Name = Name,
				Group = Group,
				Session = Guid.NewGuid().ToString("N"),
				Created = provider.GetRequiredService<IDateTime>().Now
			};

			await provider.GetRequiredService<IProfileService>().Add(profile);

			var lecture = await provider.GetRequiredService<ILectureService>()
				.OrderBy(x => x.Id)
				.FirstAsync();

			var quiz = new Quiz
			{
				Profile = profile, Lecture = lecture,
			};

			await provider.GetRequiredService<IQuizService>().Add(quiz);
			
			return new CreateProfileResponseViewModel
			{
				Session = profile.Session
			};
		}
	}
}