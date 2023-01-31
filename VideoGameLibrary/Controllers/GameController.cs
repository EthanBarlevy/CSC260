using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using VideoGameLibrary.Models;
using VideoGameLibrary.Data;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Controllers
{
    public class GameController : Controller
    {

        IDataAccessLayer DAL = new GameListDAL();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Library()
        {
            return View(DAL.GetGames());
        }

        [HttpPost]
        public IActionResult Loan(string LoanOut, int? id) 
        {
            if (!id.HasValue) return NotFound();

            DAL.Loan(id, LoanOut);
            return View("Library", DAL.GetGames());
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return NotFound();

            DAL.RemoveGame(id);
            return View("Library", DAL.GetGames());
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if (!id.HasValue) return NotFound();

            Game found = DAL.GetGame(id);

            if (found == null) return NotFound();

            return View(found);
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("Library", DAL.GetGames());
            }
            return View("Library", DAL.GetGames().Where(k => k.Title.ToLower().Contains(key.ToLower())));
        }
    }
}
