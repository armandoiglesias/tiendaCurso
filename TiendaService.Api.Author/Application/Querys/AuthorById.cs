using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.Api.Author.Models;
using TiendaService.Api.Author.Models.Persistance;

namespace TiendaService.Api.Author.Application.Querys
{
    public class AuthorById
    {
        public class Consulta : IRequest<Models.Application.AuthorDto>
        {
            public Consulta(string id)
            {
                Id = id;
            }
            public String Id { get; set; }
        }

        public class Handler : IRequestHandler<Consulta, Models.Application.AuthorDto>
        {
            ContextAuthor _context;
            IMapper _mapper;
            public Handler( ContextAuthor context, IMapper mapper )
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Models.Application.AuthorDto> Handle(Consulta request, CancellationToken cancellationToken)
            {
                var _model = await _context.Author.Where(p => p.Id.ToString() == request.Id).FirstOrDefaultAsync();
                if (_model != null)
                {
                    var _modelDTO = _mapper.Map<Models.Author, Models.Application.AuthorDto>(_model);
                    return _modelDTO;
                }
                return null;
            }
        }
    }
}
