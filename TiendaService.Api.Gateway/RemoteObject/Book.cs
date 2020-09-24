using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.Api.Gateway.RemoteObject
{
    public class Book
    {
        public Guid? StoreId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
