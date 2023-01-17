using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
	public class MovieController : Controller
	{
		private static List<Movie> MovieList = new List<Movie>
		{
			new Movie("Lion King", 1994, 3.6f),
			new Movie("Trip to the Moon", 1902, 4.1f),
			new Movie("Megamind", 2010, 6.0f)
		};

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult DisplayMovie()
		{
			Movie m = new Movie("Fantastic Mr. Fox", 2009, 4.5f);
			return View(m);
		}

		public IActionResult MultMovies() 
		{ 
			return View(MovieList);
		}
	}
}

// DateTime dt = DateTime.Now
// Model.Count()
// LoanDate = null
// Model.LoanDate.HasValue
// LoanDate.Value.ToShortDateString() "1/1/1111"
// LoanDate.Value.ToLongDateString() "January 1, 1111"
// model will store the filename for the image <img src"/images/@Model.ImageName" />
// Game oneame = lstGames.Find(g => g.ID == ID);
// lstGames.FindIndex(g => g.ID ==ID);
// use a form for loaning