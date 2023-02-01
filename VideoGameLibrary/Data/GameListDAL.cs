using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Data
{
    public class GameListDAL : IDataAccessLayer
    {
        private static List<Game> GameList = new List<Game>
        {
            new Game("Sea of Thieves", "PC", "Adventure", "T", 2018, "https://upload.wikimedia.org/wikipedia/en/7/77/Sea_of_thieves_cover_art.jpg"),
            new Game("Celeste", "PC", "Platformer", "E10+", 2018, "https://upload.wikimedia.org/wikipedia/commons/7/75/Celeste_box_art_final_2.png"),
            new Game("Nier: Automata", "PC", "Action", "M", 2017, "https://image.api.playstation.com/cdn/UP0082/CUSA04551_00/WkgJ8OLvEkfoZmY65B8cudKYw8Aylp1y.png"),
            new Game("Stardew Valley", "PC", "Casual", "E10+", 2016, "https://upload.wikimedia.org/wikipedia/en/f/fd/Logo_of_Stardew_Valley.png"),
            new Game("Monster Hunter World", "PC", "Action", "T", 2018, "https://image.api.playstation.com/vulcan/img/cfn/11307RW7B5mvRMeOG-1pM9RnGdpRQVQ2iXinFe9755wHVXH0-mRqwizRWZQK8wMHat3XhtITgBGvRuT7JLJkkZenNxUerkoj.png")
        };

        public void AddGame(Game game)
        {
            GameList.Add(game);
        }

        public void EditGame(Game game)
        {
            GameList[GetGame(game)] = game;
        }

        public Game GetGame(int? id)
        {
            return GameList.Where(m => m.Id == id).FirstOrDefault();
        }

        public int GetGame(Game game)
        {
            return GameList.FindIndex(x => x.Id == game.Id);
        }

        public IEnumerable<Game> GetGames()
        {
            return GameList;
        }

        public void RemoveGame(int? id)
        {
            GameList.Remove(GetGame(id));
        }

        public void Loan(int? id, string LoanOut)
        {
            GetGame(id).Loan(LoanOut);
        }

		public IEnumerable<Game> Search(string key)
		{
            return GetGames().Where(k => k.Title.ToLower().Contains(key.ToLower()));
		}
	}
}
