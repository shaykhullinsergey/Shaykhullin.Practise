namespace Practice
{
	public interface ILectureService : IService<Lecture>
	{
	    
	}
	
	internal class LectureService : Service<Lecture>, ILectureService
	{
		public LectureService(PracticeDatabaseContext databaseContext) : base(databaseContext.Lectures)
		{
		}
	}
}