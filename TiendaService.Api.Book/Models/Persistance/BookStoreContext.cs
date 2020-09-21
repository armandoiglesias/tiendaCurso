using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.Api.Book.Models.Persistance
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext( DbContextOptions<BookStoreContext> options  ) : base(options)
        {

        }

        public DbSet<Store> Store { set; get; }
    }
}
