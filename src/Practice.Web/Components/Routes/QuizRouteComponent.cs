using Shelter;

namespace Practice
{
	public class QuizRouteComponent : RouteComponent<QuizController>
	{
		public QuizRouteComponent()
		{
			Route(x => x.Result(From.Query<string>(), From.Body<QuizRequestViewModel>()))
				.HttpPost();
		}
	}
}