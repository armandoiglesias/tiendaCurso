using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.WebApi.Cart.Models.Persistance;
using TiendaService.WebApi.Cart.RemoteInterface;

namespace TiendaService.WebApi.Cart.Application
{
    public class Query
    {
        public class Execute : IRequest<CartDto>
        {
            public int CartSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, CartDto>
        {
            CartContext _context;
            IBookInterface _bookService;

            public Handler(CartContext context, IBookInterface bookService)
            {
                _context = context;
                _bookService = bookService;
            }

            public async Task<CartDto> Handle(Execute request, CancellationToken cancellationToken)
            {
                var cart = await _context.CartSession
                    .FirstOrDefaultAsync(p => p.CartSessionId == request.CartSessionId);

                var cartDetail = await _context.CartDetail
                    .Where(p => p.CartSessionId == request.CartSessionId)
                    .ToListAsync();

                List<CartDetailDTO> detalle = new List<CartDetailDTO>();

                foreach (var book in cartDetail)
                {
                    var response = await _bookService.getBook(new Guid(book.ProductId));
                    if (response.result)
                    {
                        var objeto = response.book;
                        detalle.Add(new CartDetailDTO() {
                            BookTitle = objeto.Title,
                            LibroId = objeto.StoreId.Value,
                            PublishDate = objeto.PublishedDate.Value,
                        });
                    }
                }

                var cartDto = new CartDto()
                {
                    CartId = cart.CartSessionId,
                    CreatedAt = cart.CreatedAt,
                    ProductList = detalle,
                };

                return cartDto;
               
            }
        }
    }
}
