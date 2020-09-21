using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.WebApi.Cart.Models
{
    public class CartSession
    {
        public int CartSessionId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<CartDetail> DetailList { get; set; }
    }
}
