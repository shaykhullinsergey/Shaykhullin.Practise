using Microsoft.AspNetCore.Mvc;

namespace Practice
{
	public class IndexController : Controller
	{
		public IActionResult Index()
		{
			return View("Index");
		}
	}
}