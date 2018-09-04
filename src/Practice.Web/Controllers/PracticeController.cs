using System;
using Microsoft.AspNetCore.Mvc;

namespace Practice
{
	[Controller]
	public class PracticeController
	{
		protected IServiceProvider Provider => ControllerContext.HttpContext.RequestServices;
		
		[ControllerContext]
		public ControllerContext ControllerContext { get; set; }
	}
}