using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {
		private static List<Game> GameList = new List<Game>
		{
			new Game("Sea of Thieves", "PC", "Action-Adventure", "T", 2018, "/images/Sea_of_thieves_cover_art.jpg"),
			new Game("Sea of Thieves", "PC", "Action-Adventure", "T", 2018, "/images/Sea_of_thieves_cover_art.jpg", "Jerry", DateTime.Now)
		};
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Library()
        {
            return View(GameList);
        }

        public IActionResult Loan() 
        {

            return Library();
        }
    }
}
