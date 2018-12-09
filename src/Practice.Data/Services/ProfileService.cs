namespace Practice
{
	public interface IProfileService : IService<Profile>
	{
	}
	
	internal class ProfileService : Service<Profile>, IProfileService
	{
		public ProfileService(PracticeDatabaseContext databaseContext) : base(databaseContext.Profiles)
		{
		}
	}
}