using Shelter;

namespace Practice
{
	public class LectureRouteComponent : RouteComponent<LectureController>
	{
		public LectureRouteComponent()
		{
			Route("{id}", x => x.Read(From.Route<int>()))
				.HttpGet();
		}
	}
}