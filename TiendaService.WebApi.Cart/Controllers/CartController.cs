using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaService.WebApi.Cart.Application;

namespace TiendaService.WebApi.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        IMediator mediator;

        public CartController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CartNew.Execute data)
        {
            return await mediator.Send(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CartDto>> getCart([FromRoute] int Id)
        {
            return await mediator.Send(new Query.Execute() { CartSessionId = Id });
        }

        
    }
}