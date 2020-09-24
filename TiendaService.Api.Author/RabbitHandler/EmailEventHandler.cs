using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaService.RabbitMQ.Bus.BusRabbit;
using TiendaService.RabbitMQ.Bus.EventQueue;

namespace TiendaService.Api.Author.RabbitHandler
{
    public class EmailEventHandler : IEventHandler<EmailEventQueue>
    {
        ILogger<EmailEventHandler> _lofger;

        public EmailEventHandler(ILogger<EmailEventHandler> lofger)
        {
            _lofger = lofger;
        }

        
        public Task Handle(EmailEventQueue @event)
        {
            _lofger.LogInformation($"***********     Titulo del Mensaje { @event.Title } *********");
            return Task.CompletedTask;
        }
    }
}
