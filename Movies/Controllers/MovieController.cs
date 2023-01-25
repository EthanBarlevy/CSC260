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

		public IActionResult ParamTest(int? id)
		{
			//return Content("things");
			return Content($"id = {id?.ToString() ?? "NULL"}");
			// ?? = null coalescing operator, (if left is null, do right)
			// id? = check if null, if it is dont do the next thing
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Movie m)
		{
			if (ModelState.IsValid)
			{ 
				MovieList.Add(m);
				TempData["success"] = "Movie " + m.Title + " created";
				return View("MultMovies", MovieList);
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int? id) 
		{
			if (!id.HasValue) return NotFound();

			Movie found = MovieList.Where(m => m.Id == id).FirstOrDefault();

			if (found == null) return NotFound();

			return View(found);
		}

		[HttpPost]
		public IActionResult Edit(Movie movie)
		{
			int i;
			i = MovieList.FindIndex(x => x.Id == movie.Id);
			MovieList[i] = movie;
			TempData["success"] = "Movie " + movie.Title + " updated";
			return View("MultMovies", MovieList);
		}

		public IActionResult Delete(int? id) 
		{ 
			if(!id.HasValue) return NotFound();

			int i;
			i = MovieList.FindIndex(x => x.Id == id);
			TempData["success"] = "Movie " + MovieList[i].Title + " deleted";
			MovieList.RemoveAt(i);
			return View("MultMovies", MovieList);
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