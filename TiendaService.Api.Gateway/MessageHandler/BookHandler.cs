using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.Api.Gateway.RemoteInterface;
using TiendaService.Api.Gateway.RemoteObject;

namespace TiendaService.Api.Gateway.MessageHandler
{
    public class BookHandler : DelegatingHandler
    {
        ILogger<BookHandler> _logger;
        IAuthor _author;
        public BookHandler(ILogger<BookHandler> logger, IAuthor author)
        {
            _logger = logger;
            _author = author;
        }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var _tiempo = Stopwatch.StartNew();
            _logger.LogInformation("Request Start");

            var _response = await base.SendAsync(request, cancellationToken);

            if (_response.IsSuccessStatusCode)
            {
                var content = await _response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true  };
                var book = JsonSerializer.Deserialize<Book>(content, options);

                var _authorResponse =await _author.GetAuthor(book.AuthorId );
                if (_authorResponse.Result)
                {
                    book.Author = _authorResponse.author;
                    _response.Content = new StringContent( JsonSerializer.Serialize(book) , System.Text.Encoding.UTF8, "application/json");
                }


            }
            _logger.LogInformation($" execution done in { _tiempo.ElapsedMilliseconds }ms");
            return _response;
        }
    }
}
