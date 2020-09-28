
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaService.Message.Email.SendGridLibrary.Interface;
using TiendaService.RabbitMQ.Bus.BusRabbit;
using TiendaService.RabbitMQ.Bus.EventQueue;

namespace TiendaService.Api.Author.RabbitHandler
{
    public class EmailEventHandler : IEventHandler<EmailEventQueue>
    {
        ILogger<EmailEventHandler> _lofger;
        ISendGridSend _sendGridSend;

        Microsoft.Extensions.Configuration.IConfiguration _config;

        public EmailEventHandler(ILogger<EmailEventHandler> lofger, ISendGridSend sendGridSend, Microsoft.Extensions.Configuration configuration )
        {
            _lofger = lofger;
            _sendGridSend = sendGridSend;
            _config = configuration;
        }

        
        public async Task Handle(EmailEventQueue @event)
        {
            _lofger.LogInformation($"***********     Titulo del Mensaje { @event.Title } *********");

            var result = await _sendGridSend.SendEmail(new Message.Email.SendGridLibrary.Models.Data()
            {
                Title = @event.Title,
                To = @event.To,
                Body = @event.Body,
                NameTo = @event.To,
                SendGridApiKey = _config["SendGrid:APIKey"]
            });

            if (result.Result)
            {
                await  Task.CompletedTask;
                return;
            }



        }
    }
}
