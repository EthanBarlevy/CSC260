using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Data
{
    public class GameListDAL : IDataAccessLayer
    {
        private AppDbContext db;
        public GameListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddGame(Game game)
        {
            db.Games.Add(game);
        }

        public void EditGame(Game game)
        {
            db.Games[GetGame(game)] = game;
        }

        public Game GetGame(int? id)
        {
            return db.Games.Where(m => m.Id == id).FirstOrDefault();
        }

        public int GetGame(Game game)
        {
            return db.Games.FindIndex(x => x.Id == game.Id);
        }

        public IEnumerable<Game> GetGames()
        {
            return db.Games;
        }

        public void RemoveGame(int? id)
        {
            db.Games.Remove(GetGame(id));
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
