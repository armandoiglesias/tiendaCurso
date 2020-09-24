using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TiendaService.RabbitMQ.Bus.Commands;
using TiendaService.RabbitMQ.Bus.Events;

namespace TiendaService.RabbitMQ.Bus.BusRabbit
{
    public interface IRabbitEventBus
    {
        Task SendCommand<T>(T comando) where T : Comando;

        void Publish<T>(T @event) where T : Evento;

        void Subscribe<T, TH>() where T : Evento where TH : IEventHandler<T>;

    }
}
