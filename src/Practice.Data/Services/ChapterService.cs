namespace Practice
{
	public interface IChapterService : IService<Chapter>
	{
	}
	
	internal class ChapterService : Service<Chapter>, IChapterService
	{
		public ChapterService(PracticeContext context) : base(context.Chapters)
		{
		}
	}
}