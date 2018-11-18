using Shelter;

namespace Practice
{
	public class PracticeRouterComponent : RouterComponent
	{
		public PracticeRouterComponent()
		{
			Controller<
				ProfileController,
				ProfileRouteComponent>("profiles");

			Controller<
				LectureController,
				LectureRouteComponent>("lectures");

			Controller<
				QuizController,
				QuizRouteComponent>("quizzes");
		}
	}
}