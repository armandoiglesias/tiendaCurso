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
    public class GetBook
    {
        public class Book : IRequest<BookDto>
        {
            public Guid Id { get; set; }

            public Book(Guid id)
            {
                Id = id;
            }

        }

        public class Handler : IRequestHandler<Book, BookDto>
        {
            BookStoreContext _context;
            IMapper _mapper;
            public Handler( BookStoreContext context, IMapper mapper )
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookDto> Handle(Book request, CancellationToken cancellationToken)
            {
                var book = await _context.Store.Where(p => p.StoreId == request.Id).FirstOrDefaultAsync();

                if (book == null)
                {
                    throw new Exception("Error al consulta");
                }

                var _book = _mapper.Map< Store,  BookDto >(book);
                return _book;
            }
        }
    }
}
