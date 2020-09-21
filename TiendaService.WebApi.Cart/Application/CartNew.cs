using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.WebApi.Cart.Models.Persistance;

namespace TiendaService.WebApi.Cart.Application
{
    public class CartNew 
    {
        

        public class Execute : IRequest
        {
            public DateTime? CreatedAt { get; set; }

            public List<string> ProductList { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            CartContext _cartContext;

            public Handler(CartContext cartContext)
            {
                _cartContext = cartContext;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var _cart = new Models.CartSession() { CreatedAt = request.CreatedAt.Value };
                _cartContext.CartSession.Add( _cart);

                int txId = await  _cartContext.SaveChangesAsync();

                if (txId == 0)
                {
                    throw new Exception("Error al crear Cart");
                }

                int cartId = _cart.CartSessionId;

                foreach (var item in request.ProductList)
                {
                    var detalle = new Models.CartDetail()
                    {
                        CartSessionId = cartId,
                        CreatedAt = DateTime.Now,
                        ProductId = item
                    };

                    _cartContext.CartDetail.Add(detalle);
                    
                }

                int transId =await _cartContext.SaveChangesAsync();

                if (transId == 0)
                {
                    throw new Exception("Error guardando detalles");
                }

                return Unit.Value;
            }
        }
    }
}
