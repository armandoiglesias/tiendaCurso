using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.Api.Author.Models.Persistance
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options): base(options)
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<EducationDegree> AuthorEducationDegree { get; set; }
    }
}
