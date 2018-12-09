using Shelter;

namespace Practice
{
	public class IndexRouteComponent : RouteComponent<IndexController>
	{
		public IndexRouteComponent()
		{
			Route(x => x.Index()).HttpGet();
		}
	}
}