using Shelter;

namespace Practice
{
	public class TaskRouteComponent : RouteComponent<TaskController>
	{
		public TaskRouteComponent()
		{
			Route(
				"complete", 
				c => c.Complete(
					From.Query<string>(), 
					From.Body<TaskCompleteViewModel>()))
						.HttpPost();
		}
	}
}