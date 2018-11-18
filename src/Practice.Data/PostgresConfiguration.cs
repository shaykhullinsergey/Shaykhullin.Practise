using System.Runtime.Serialization;
using Shelter;

namespace Practice
{
	[DataContract]
	public class PostgresConfiguration : Configuration, IConfiguration
	{
		[DataMember(Name = "userId")]
		public string UserId { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }

		[DataMember(Name = "host")]
		public string Host { get; set; }

		[DataMember(Name = "port")]
		public int Port { get; set; }

		[DataMember(Name = "database")]
		public string Database { get; set; }

		[DataMember(Name = "pooling")]
		public bool Pooling { get; set; }

		public string GetConnectionString()
		{
			return $"User ID={UserId};Password={Password};Host={Host};Port={Port};Database={Database};Pooling={Pooling};";
		}
	}
}