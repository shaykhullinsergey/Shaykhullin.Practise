using Microsoft.AspNetCore.Mvc;

namespace Practice
{
	[Route("")]
	public class IndexController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View("Index");
		}
	}
}