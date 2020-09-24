using System;
using System.Collections.Generic;
using System.Text;
using TiendaService.RabbitMQ.Bus.Events;

namespace TiendaService.RabbitMQ.Bus.EventQueue
{
    public class EmailEventQueue : Evento
    {
        public string To { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public EmailEventQueue(string to, string title, string body)
        {
            To = to;
            Title = title;
            Body = body;
        }
    }
}
