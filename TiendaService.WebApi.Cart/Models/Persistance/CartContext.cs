using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.WebApi.Cart.Models.Persistance
{
    public class CartContext : DbContext
    {

        public CartContext(DbContextOptions<CartContext> options ): base(options)
        {

        }

        public DbSet<CartSession> CartSession { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
    }
}
