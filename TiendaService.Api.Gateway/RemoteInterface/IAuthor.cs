using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaService.Api.Gateway.RemoteObject;

namespace TiendaService.Api.Gateway.RemoteInterface
{
    public interface IAuthor
    {
        Task<(bool Result, Author author, string ErrorMessage)> GetAuthor(Guid AuthorId);
    }
}
