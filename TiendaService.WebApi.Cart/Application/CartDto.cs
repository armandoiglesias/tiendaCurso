using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.WebApi.Cart.Application
{
    public class CartDto
    {
        public int CartId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<CartDetailDTO> ProductList { get; set; }

    }
}
