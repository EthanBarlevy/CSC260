using VideoGameLibrary.Models;
using VideoGameLibrary.Interfaces;

namespace VideoGameLibrary.Data
{
    public class VideoGameDBDAL : IDataAccessLayer
    {
        private AppDbContext db;
        public VideoGameDBDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddGame(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges(); // save or else lol
        }

        public void EditGame(Game game)
        {
            db.Games.Update(game);
            db.SaveChanges();
        }

        public Game GetGame(int? id)
        {
            return db.Games.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Game> GetGames()
        {
            return db.Games.OrderBy(g => g.Title).ToList();
        }

        public void RemoveGame(int? id)
        {
            db.Games.Remove(GetGame(id));
            db.SaveChanges();
        }

        public void Loan(int? id, string LoanOut)
        {
            GetGame(id).Loan(LoanOut);
            db.SaveChanges();
        }

		public IEnumerable<Game> Search(string key)
		{
            return GetGames().Where(k => k.Title.ToLower().Contains(key.ToLower()));
		}
	}
}
