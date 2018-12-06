using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Shelter;

namespace Practice.Alex
{
	class Program
	{
		static void Main(string[] args)
		{
			new WebHostBuilder()
				.ConfigureServices(services =>
					services.AddModule<PracticeDataModule>());
		}
	}
}