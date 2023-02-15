﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Game> Games { get; set; } // associates a class with a table
    }
}
