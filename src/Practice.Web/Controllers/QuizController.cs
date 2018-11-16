using System.Threading.Tasks;

namespace Practice
{
	public class QuizController : PracticeController
	{
		public async Task<QuizResponseViewModel> Result(string session, QuizRequestViewModel model)
		{
			return await model.Result(Provider, session);
		}
	}
}