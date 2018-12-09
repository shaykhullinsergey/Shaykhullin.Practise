namespace Practice
{
	public interface IChapterService : IService<Chapter>
	{
	}
	
	internal class ChapterService : Service<Chapter>, IChapterService
	{
		public ChapterService(PracticeDatabaseContext databaseContext) : base(databaseContext.Chapters)
		{
		}
	}
}