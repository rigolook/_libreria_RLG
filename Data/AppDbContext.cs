﻿using _libreria_RLG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _libreria_RLG.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
