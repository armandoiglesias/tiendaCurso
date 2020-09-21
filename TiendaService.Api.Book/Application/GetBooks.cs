using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.Api.Book.Models;
using TiendaService.Api.Book.Models.Persistance;

namespace TiendaService.Api.Book.Application
{
    public class GetBooks
    {
        public class Execute  : IRequest<List<BookDto>>
        {

        }

        public class Handler : IRequestHandler<Execute, List<BookDto>>
        {
            BookStoreContext _context;
            IMapper _mapper;
            public Handler(BookStoreContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BookDto>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var _records = await  _context.Store.ToListAsync();
                var _return = _mapper.Map< List<Store>, List<BookDto> >(_records);

                return _return;
            }
        }
    }
}
