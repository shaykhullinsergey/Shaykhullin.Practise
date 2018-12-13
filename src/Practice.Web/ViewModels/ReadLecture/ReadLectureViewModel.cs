using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;

namespace Practice
{
	public class ReadLectureViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "chapters")]
		public ICollection<ReadLectureChapterViewModel> Chapters { get; set; }
		
		[DataMember(Name = "questions")]
		public ICollection<ReadLectureQuestionViewModel> Questions { get; set; }

		public async Task Load(IServiceProvider provider, int id)
		{
			var lecture = await provider.GetRequiredService<ILectureService>().FirstAsync(x => x.Id == id);

			Title = lecture.Title;
	
			Chapters = lecture.Chapters
				.OrderBy(x => x.Order)
				.Select(x => new ReadLectureChapterViewModel(x))
				.ToList();

			Questions = lecture.Questions
				.Shuffle()
				.Take(5)
				.Select(x => new ReadLectureQuestionViewModel(x))
				.ToList();
		}
	}
	
	public class ReadLectureChapterViewModel
	{
		[DataMember(Name = "title")]
		public string Title { get; }
		
		[DataMember(Name = "text")]
		public string Text { get; }
		
		public ReadLectureChapterViewModel(Chapter chapter)
		{
			Title = chapter.Title;
			Text = chapter.Text;
		}
	}
	
	public class ReadLectureQuestionViewModel
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }
		
		[DataMember(Name = "text")]
		public string Text { get; }

		[DataMember(Name = "answers")]
		public ICollection<ReadLectureAnswerViewModel> Answers { get; }

		public ReadLectureQuestionViewModel(Question question)
		{
			Id = question.Id;
			Text = question.Text;

			Answers = question.Answers
				.Shuffle()
				.Select(x => new ReadLectureAnswerViewModel(x))
				.ToList();
		}
	}
	
	public class ReadLectureAnswerViewModel
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }
		
		[DataMember(Name = "text")]
		public string Text { get; set; }
		
		public ReadLectureAnswerViewModel(Answer answer)
		{
			Id = answer.Id;
			Text = answer.Text;
		}
	}
}