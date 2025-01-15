using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookstoreApp.Models;

namespace BookstoreApp.Data
{
    public class BookstoreAppContext : DbContext
    {
        public BookstoreAppContext (DbContextOptions<BookstoreAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookstoreApp.Models.Book> Book { get; set; } = default!;
    }
}
