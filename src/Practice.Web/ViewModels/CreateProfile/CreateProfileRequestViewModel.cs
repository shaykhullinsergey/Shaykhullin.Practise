using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Practice
{
	public class CreateProfileRequestViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		public async Task<CreateProfileResponseViewModel> Create(IServiceProvider provider)
		{
			var profile = new Profile
			{
				Name = Name,
				Session = Guid.NewGuid().ToString("N")
			};

			await provider.GetRequiredService<IProfileService>().Add(profile);

			return new CreateProfileResponseViewModel
			{
				Session = profile.Session
			};
		}
	}
}