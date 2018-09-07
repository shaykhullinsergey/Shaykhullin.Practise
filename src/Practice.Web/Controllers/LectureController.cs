using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Practice
{
	public class LectureController : PracticeController
	{
		public async Task<ReadLectureViewModel> Read(int id)
		{
			var model = new ReadLectureViewModel();

			await model.Load(Provider, id);

			return model;
		}
	}
	
	public class QuizController : PracticeController
	{
		public async Task<QuizResponseViewModel> Result(string session, QuizRequestViewModel model)
		{
			return await model.Result(Provider, session);
		}
	}
}