using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shelter;

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

			var validationContext = provider.GetRequiredService<IValidationContext>();
			
			validationContext.Validate()
				.If(() => Questions.Select(x => x.QuestionId).Distinct().Count() != Questions.Count)
				.Throw<CreateProfileRequestValidationSection>(c => c.QuestionsMustBeUnique);

			var results = new bool[Questions.Count];

			var count = 0;
			
			foreach (var question in Questions)
			{
				var input = lecture.Questions.FirstOrDefault(x => x.Id == question.QuestionId);

				if (input != null)
				{
					var answer = input.Answers.First(x => x.Id == question.AnswerId);
					
					results[count] = answer.Correct;
				}

				count++;
			}

			var result = results.Count(x => x);
			
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
					var alreadyAdded = provider.GetRequiredService<IQuizService>()
						.Any(x => x.Profile == profile && x.Lecture == nextLecture);

					if (!alreadyAdded)
					{
						await provider.GetRequiredService<IQuizService>()
							.Add(new Quiz
							{
								Profile = profile, Lecture = nextLecture
							});
					}
				}
			}
			
			var statistics = await provider
				.GetRequiredService<IQuizService>()
				.Where(x => x.Lecture == lecture && x.Result != null)
				.GroupBy(x => x.Result)
				.OrderBy(x => x.Key)
				.ToDictionaryAsync(
					x => x.Key.Value,
					x => x.Count());
			
			return new QuizResponseViewModel
			{
				Results = results,
				Statistics = statistics
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
		
		[DataMember(Name = "results")]
		public ICollection<bool> Results { get; set; }
		
		[DataMember(Name = "statistics")]
		public IDictionary<int, int> Statistics { get; set; }
	}
}