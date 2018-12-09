using System.Collections.Generic;

namespace Practice
{
	public static class DatabaseConfiguration
	{
		public static bool ShouldUpdateDatabase => false;
		
		public static void Configure(PracticeDatabaseContext context)
		{
			Truncate(context);

			var lectures = CreateLectures();
			
			context.Lectures.AddRange(lectures);

			context.SaveChanges();
		}

		private static void Truncate(PracticeDatabaseContext context)
		{
			context.Answers.RemoveRange(context.Answers);
			context.Chapters.RemoveRange(context.Chapters);
			context.Lectures.RemoveRange(context.Lectures);
			context.Questions.RemoveRange(context.Questions);
			context.Quizzes.RemoveRange(context.Quizzes);
			context.Profiles.RemoveRange(context.Profiles);
			
			context.SaveChanges();
		}

		private static IEnumerable<Lecture> CreateLectures()
		{
			yield return Lecture1();
			// yield return Lecture2();
		}

		private static Lecture Lecture1()
		{
			#region Вопросы
			var questions = new List<Question>
			{
				new Question
				{
					Text = "Вопрос 1",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 2",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = false },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = true },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 3",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				new Question
				{
					Text = "Вопрос 4",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = true },
					}
				},
				new Question
				{
					Text = "Вопрос 5",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				}
			};
			#endregion

			#region Главы
			
			var chapters = new List<Chapter>
			{
				new Chapter
				{
					Title = "Глава 1", Text = "Топ контент первой главы"
				},
				new Chapter
				{
					Title = "Глава 2", Text = "Топ контент второй главы"
				},
			};
			
			#endregion
			
			return new Lecture
			{
				Title = "Лекция 1",
				Chapters = chapters,
				Questions = questions 
			};
		}
		
		private static Lecture Lecture2()
		{
			#region Вопросы
			var questions = new List<Question>
			{
				new Question
				{
					Text = "Вопрос 1",
					Answers = new List<Answer>
					{
						new Answer { Text = "Ответ 1", Correct = true },
						new Answer { Text = "Ответ 2", Correct = false },
						new Answer { Text = "Ответ 3", Correct = false },
						new Answer { Text = "Ответ 4", Correct = false }
					}
				},
				// new Question()
			};
			#endregion

			#region Главы
			
			var chapters = new List<Chapter>
			{
				new Chapter
				{
					Title = "Глава 1", Text = "Топ контент первой главы"
				},
				// new Chapter()
			};
			
			#endregion
			
			return new Lecture
			{
				Title = "Лекция 1",
				Chapters = chapters,
				Questions = questions 
			};
		}
	}
}