using IDPractice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace IDPractice.Controllers
{
	//[Authorize] you can also do whole controller authorize required
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

		// can also allow for role spesific authorization
		//[Authorize (Roles = "Admin")] // single page autorize required
		public IActionResult Privacy()
		{
			string x;
			//x = User.FindFirstValue(ClaimTypes.Name); // name is username
			//x = User.FindFirstValue(ClaimTypes.Email);
			x = User.FindFirstValue(ClaimTypes.NameIdentifier); // id of user

			return Content(x);
			//return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}