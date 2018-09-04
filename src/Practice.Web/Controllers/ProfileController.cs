using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Practice
{
	[Route("profiles")]
	public class ProfileController : PracticeController
	{
		[HttpPost]
		public async Task<CreateProfileResponseViewModel> Create([FromBody] CreateProfileRequestViewModel model)
		{
			return await model.Create(Provider);
		}

		[HttpGet]
		public async Task<ReadProfileResponseViewModel> Read([FromQuery] ReadProfileRequestViewModel model)
		{
			return await model.Read(Provider);
		}
	}
}