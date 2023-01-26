using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {
		private static List<Game> GameList = new List<Game>
		{
			new Game("Sea of Thieves", "PC", "Adventure", "T", 2018, "/images/Sea_of_thieves_cover_art.jpg"),
			new Game("Celeste", "PC", "Platformer", "E10+", 2018, "/images/Celeste_box_art_final.png"),
			new Game("Nier: Automata", "PC", "Action", "M", 2017, "/images/Nier-Automata.png"),
			new Game("Stardew Valley", "PC", "Casual", "E10+", 2016, "/images/Logo_of_Stardew_Valley.png"),
			new Game("Monster Hunter World", "PC", "Action", "T", 2018, "/images/World-iceborne.png")
		};
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Library()
        {
            return View(GameList);
        }

        public IActionResult Loan(string LoanOut, int index) 
        {
            for (int i = 0; i < GameList.Count(); i++)
            {
                if (GameList[i].Id == index)
                {
                    GameList[i].Loan(LoanOut);
                }
            }
            return View("Library", GameList);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();

            int i;
            i = GameList.FindIndex(x => x.Id == id);
            GameList.RemoveAt(i);
            return View("Library", GameList);
        }
    }
}
