using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Practice
{
	public class ReadProfileRequestViewModel
	{
		[DataMember(Name = "session")]
		public string Session { get; set; }
		
		public async Task<ReadProfileResponseViewModel> Read(IServiceProvider provider)
		{
			var profile = await provider.GetRequiredService<IProfileService>()
				.FirstAsync(x => x.Session == Session);
			
			var model = new ReadProfileResponseViewModel();

			await model.Load(profile);

			return model;
		}
	}
}