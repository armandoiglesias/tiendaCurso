using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaService.Api.Author.Application;
using TiendaService.Api.Author.Application.Querys;

namespace TiendaService.Api.Author.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Unit>> createAuthor(Nuevo.Ejecuta _create)
        {
            return await _mediator.Send(_create);
        }

        [HttpGet]
        [Route("Authors")]
        public async Task<ActionResult<List<Models.Application.AuthorDto>>> getAuthors()
        {
            return await _mediator.Send( new Query.AuthorList()  );
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<Models.Application.AuthorDto>> getAuthors([FromRoute] string Id)
        {
            return await _mediator.Send(new AuthorById.Consulta(Id));
        }

    }
}