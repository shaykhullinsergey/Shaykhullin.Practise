using System.Threading.Tasks;

namespace Practice
{
	public class ProfileController : PracticeController
	{
		public async Task<CreateProfileResponseViewModel> Create(CreateProfileRequestViewModel model)
		{
			var result = await model.Create(Provider);
			
			return result;
		}

		public async Task<ReadProfileResponseViewModel> Read(ReadProfileRequestViewModel model)
		{
			return await model.Read(Provider);
		}
	}
}