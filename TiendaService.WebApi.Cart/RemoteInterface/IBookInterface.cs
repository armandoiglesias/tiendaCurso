using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaService.WebApi.Cart.RemoteModel;

namespace TiendaService.WebApi.Cart.RemoteInterface
{
    public interface IBookInterface
    {
        Task<(bool result, RemoteBook book, string ErrorMessage )> getBook(Guid bookId);
    }
}
