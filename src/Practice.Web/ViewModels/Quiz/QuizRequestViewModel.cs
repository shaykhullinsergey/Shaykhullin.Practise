using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Practice
{
	public class QuizRequestViewModel
	{
		[DataMember(Name = "lectureId")]
		public int LectureId { get; set; }

		[DataMember(Name = "questions")]
		public ICollection<QuizRequestQuestionViewModel> Questions { get; set; }
		
		public async Task<QuizResponseViewModel> Result(IServiceProvider provider, string session)
		{
			var profile = await provider.GetRequiredService<IProfileService>()
				.FirstAsync(x => x.Session == session);

			var lecture = await provider.GetRequiredService<ILectureService>()
				.FirstAsync(x => x.Id == LectureId);

			var quiz = await provider.GetRequiredService<IQuizService>()
				.FirstAsync(x => x.Profile == profile && x.Lecture == lecture);

			var result = 0;

			foreach (var question in lecture.Questions)
			{
				var input = Questions.FirstOrDefault(x => x.QuestionId == question.Id);

				if (input != null)
				{
					var answer = question.Answers.First(x => x.Id == input.AnswerId);
					
					result += answer.Correct ? 1 : 0;
				}
			}
			
			if (quiz.Result == null || quiz.Result < result)
			{
				quiz.Result = result;
			}

			if (quiz.Result == 5)
			{
				var nextLecture = await provider.GetRequiredService<ILectureService>()
					.FirstOrDefaultAsync(x => x.Id > lecture.Id);

				if (nextLecture != null)
				{
					await provider.GetRequiredService<IQuizService>()
						.Add(new Quiz
						{
							Profile = profile, Lecture = nextLecture
						});
				}
			}
			
			return new QuizResponseViewModel
			{
				Result = result
			};
		}
	}
	
	public class QuizRequestQuestionViewModel
	{
		[DataMember(Name = "questionId")]
		public int QuestionId { get; set; }
		
		[DataMember(Name = "answerId")]
		public int AnswerId { get; set; }
	}
	
	public class QuizResponseViewModel
	{
		public int Result { get; set; }
	}
}