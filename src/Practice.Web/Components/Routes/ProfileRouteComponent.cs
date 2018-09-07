using Shelter;

namespace Practice
{
	public class ProfileRouteComponent : RouteComponent<ProfileController>
	{
		public ProfileRouteComponent()
		{
			Route(x => x.Create(From.Body<CreateProfileRequestViewModel>()))
				.HttpPost();

			Route(x => x.Read(From.Query<ReadProfileRequestViewModel>()))
				.HttpGet();
		}
	}
}