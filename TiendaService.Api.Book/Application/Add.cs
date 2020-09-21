using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.Api.Book.Models.Persistance;

namespace TiendaService.Api.Book.Application
{
    public class Add
    {
        public class AddBook : IRequest
        {
            public string Title { get; set; }
            public DateTime? PublishDate { get; set; }
            public Guid? AuthorId { get; set; }

        }

        public class AddBookValidation : AbstractValidator<AddBook>
        {
            public AddBookValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublishDate).NotEmpty();
                RuleFor(x => x.AuthorId).NotEmpty();
            }

        }

        public class Handler : IRequestHandler<AddBook>
        {
            BookStoreContext _context;

            public Handler(BookStoreContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(AddBook request, CancellationToken cancellationToken)
            {
                _context.Store.Add(new Models.Store()
                {
                    AuthorId = request.AuthorId.Value,
                    PublishedDate = request.PublishDate,
                    Title = request.Title,
                    StoreId = Guid.NewGuid()
                });

                int response = await _context.SaveChangesAsync();

                if (response > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error al guardar book");
            }
        }

    }
}
