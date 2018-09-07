using System.Runtime.Serialization;
using Shelter;

namespace Practice
{
	public class PracticeConfiguration : Configuration
	{
		[DataMember(Name = "postgres")]
		public PostgresConfiguration Postgres { get; set; }
	}
}