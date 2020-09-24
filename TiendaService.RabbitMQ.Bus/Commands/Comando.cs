using System;
using System.Collections.Generic;
using System.Text;
using TiendaService.RabbitMQ.Bus.Events;

namespace TiendaService.RabbitMQ.Bus.Commands
{
    public abstract class Comando : Message
    {
        public DateTime TimeStamp { get; protected set; }

        public Comando()
        {
            this.TimeStamp = DateTime.Now; 
        }

    }
}
