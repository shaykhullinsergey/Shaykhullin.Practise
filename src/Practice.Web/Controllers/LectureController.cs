using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Practice
{
	[Route("lectures")]
	public class LectureController : PracticeController
	{
		[HttpGet]
		public async Task<ReadLectureViewModel> Read(int id)
		{
			var model = new ReadLectureViewModel();

			await model.Load(Provider, id);

			return model;
		}
	}
}