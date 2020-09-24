using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaService.RabbitMQ.Bus.Events
{
    public abstract class Evento
    {
        public DateTime TimeStamp { get; set; }

        protected Evento()
        {
            this.TimeStamp = DateTime.Now;
        }
    }
}
