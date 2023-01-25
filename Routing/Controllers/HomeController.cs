using Microsoft.AspNetCore.Mvc;
using Routing.Models;
using System.Diagnostics;

namespace Routing.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		[Route("/")]
		public IActionResult Index()
		{
			return View();
		}

		[Route("{id}/{name?}")]
		public IActionResult Cow(int id, string? name) 
		{
			if (name == null)
			{
				return Content($"The cow Jerry moos at you {id} times.");
			}
			else 
			{
				return Content($"The cow {name} moos at you {id} times.");
			}
		}

		[Route("EatMoreChicken")]
		public IActionResult Chicken() 
		{ 
			return Redirect("https://www.chick-fil-a.com/");
		}

		[Route("AllCows/Gallery/{number}/{page?}")]
		public IActionResult Cows(int number, string? page) 
		{
			return Content($"The cow Jerry moos at you {number} times.");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View("Index");
		}
	}
}