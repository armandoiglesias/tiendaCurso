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
    public partial class Query
    {
        public class AuthorList : IRequest<List<Models.Application.AuthorDto>>
        {

        }

        public class Handler : IRequestHandler<AuthorList, List<Models.Application.AuthorDto>>
        {
            ContextAuthor _context;

            IMapper _mapper;

            public Handler(ContextAuthor context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<Models.Application.AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var records =  await _context.Author.ToListAsync();
                var recordsDTO = _mapper.Map<List<Models.Author>, List<Models.Application.AuthorDto>>(records);

                return recordsDTO;

                    
            }
        }
    }
}
