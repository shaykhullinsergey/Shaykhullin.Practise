using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Practice
{
	public class ReadProfileResponseViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		[DataMember(Name = "lectures")]
		public ICollection<ReadProfileLectureViewModel> Lectures { get; set; }
		
		public async Task Load(Profile profile)
		{
			Name = profile.Name;
			
			Lectures = profile.Quizzes
				.OrderBy(x => x.Id)
				.Select(x => new ReadProfileLectureViewModel(x))
				.ToList();
		}
	}
}