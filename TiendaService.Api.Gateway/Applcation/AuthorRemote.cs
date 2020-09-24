using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TiendaService.Api.Gateway.RemoteInterface;
using TiendaService.Api.Gateway.RemoteObject;

namespace TiendaService.Api.Gateway.Applcation
{
    public class AuthorRemote : IAuthor
    {
        ILogger<AuthorRemote> _ilogger;
        IHttpClientFactory _httpClient;
        public AuthorRemote(IHttpClientFactory client, ILogger<AuthorRemote> ilogger)
        {
            _ilogger = ilogger;
            _httpClient = client;
        }
        public async Task<(bool Result, Author author, string ErrorMessage)> GetAuthor(Guid AuthorId)
        {
            try
            {
                var client = _httpClient.CreateClient("AuthorService");
                var response = await client.GetAsync($"/Author/{AuthorId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await  response.Content.ReadAsStringAsync();
                    var author = JsonSerializer.Deserialize<Author>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (true, author, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch (Exception e)
            {
                _ilogger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
