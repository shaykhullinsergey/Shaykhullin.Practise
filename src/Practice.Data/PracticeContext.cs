using Microsoft.EntityFrameworkCore;

namespace Practice
{
	public class PracticeDatabaseContext : DbContext
	{
		public PracticeDatabaseContext()
		{
		}

		public PracticeDatabaseContext(DbContextOptions<PracticeDatabaseContext> options) : base(options)
		{
		}
		
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<Lecture> Lectures { get; set; }
		public DbSet<Chapter> Chapters { get; set; }
		public DbSet<Quiz> Quizzes { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
	}
}