using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.WebApi.Cart.Models
{
    public class CartDetail
    {
        public int CartDetailId { get; set; }
        public DateTime CreatedAt { get; set; }

        public string ProductId { get; set; }

        public int CartSessionId { get; set; }
        public CartSession CartSession { get; set; }
    }
}
