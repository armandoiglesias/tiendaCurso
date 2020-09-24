using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaService.RabbitMQ.Bus.Events;

namespace TiendaService.RabbitMQ.Bus.BusRabbit
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Evento
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
