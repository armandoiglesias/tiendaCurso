using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.WebApi.Cart.Application
{
    public class CartDetailDTO
    {
        public Guid LibroId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
