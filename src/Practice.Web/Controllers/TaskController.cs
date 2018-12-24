using System.Threading.Tasks;

namespace Practice
{
	public class TaskController : PracticeController
	{
		public async Task<TaskResultViewModel> Complete(string session, TaskCompleteViewModel model)
		{
			return await model.Complete(Provider, session);
		}
	}
}