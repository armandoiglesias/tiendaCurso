using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaService.Api.Author.Models.Persistance;

namespace TiendaService.Api.Author.Application
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }

        }

        public class EjecutaValidation : AbstractValidator<Ejecuta>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();

            }
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            ContextAuthor _context;
            public Handler(ContextAuthor contextAuthor )
            {
                _context = contextAuthor;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                _context.Author.Add(new Models.Author()
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    Id = Guid.NewGuid()
                });

                var valor = await _context.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error");
                
            }
        }
    }
}
