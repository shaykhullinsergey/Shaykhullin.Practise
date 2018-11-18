using System.Runtime.Serialization;

namespace Practice
{
	public class CreateProfileResponseViewModel
	{
		[DataMember(Name = "session")]
		public string Session { get; set; }
	}
}