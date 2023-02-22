using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			string x;
			//x = User.FindFirstValue(ClaimTypes.Name); // name is username
			//x = User.FindFirstValue(ClaimTypes.Email);
			x = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of user

			return Content(x);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}