using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaService.Api.Book.Application;

namespace TiendaService.Api.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create( Add.AddBook addBook)
        {
            return await _mediator.Send(addBook);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<BookDto>> GetBook([FromRoute] Guid Id )
        {
            return await _mediator.Send(new GetBook.Book(Id));
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            return await _mediator.Send(new GetBooks.Execute());
        }
    }
}