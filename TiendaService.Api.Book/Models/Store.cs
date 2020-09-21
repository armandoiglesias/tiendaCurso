using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.Api.Book.Models
{
    public class Store
    {
        public Guid? StoreId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
    }
}
