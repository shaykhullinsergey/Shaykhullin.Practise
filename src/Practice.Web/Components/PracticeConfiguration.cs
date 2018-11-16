using System.Runtime.Serialization;
using Shelter;

namespace Practice
{
	public class PracticeConfiguration : Configuration, IConfiguration
	{
		[DataMember(Name = "postgres")]
		public PostgresConfiguration Postgres { get; set; }
	}
}