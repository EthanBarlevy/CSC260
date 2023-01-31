﻿using VideoGameLibrary.Models;
using System.Collections.Generic;

namespace VideoGameLibrary.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Game> GetGames();
        void AddGame(Game game);
        void RemoveGame(int? id);
        Game GetGame(int? id);
        int GetGame(Game game);
        void EditGame(Game game);
        void Loan(int? id, string LoanOut);
    }
}