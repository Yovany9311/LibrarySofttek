﻿using LibrarySofttek.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibrarySofttek.Repository.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}