using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaService.WebApi.Cart.RemoteInterface;
using TiendaService.WebApi.Cart.RemoteModel;

namespace TiendaService.WebApi.Cart.RemoteServices
{
    public class BookService : IBookInterface
    {
        IHttpClientFactory _httpClient;
        ILogger<BookService> _logger;
        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger )
        {
            _httpClient = httpClient;
            _logger = logger;
        }    
        public async Task<(bool result, RemoteBook book, string ErrorMessage)> getBook(Guid bookId)
        {
            try
            {
                var client = _httpClient.CreateClient("books");
                var response = await  client.GetAsync($"api/book/{ bookId }");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    var result =JsonSerializer.Deserialize<RemoteBook>(content, options);
                    return (true, result, "");
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return( false, null, e.Message);
            }
        }
    }
}
