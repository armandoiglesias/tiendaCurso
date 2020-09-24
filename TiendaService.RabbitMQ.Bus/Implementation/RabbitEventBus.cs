using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaService.RabbitMQ.Bus.BusRabbit;
using TiendaService.RabbitMQ.Bus.Commands;
using TiendaService.RabbitMQ.Bus.Events;

namespace TiendaService.RabbitMQ.Bus.Implementation
{
    public class RabbitEventBus : IRabbitEventBus
    {
        IMediator _mediator;

        Dictionary<string, List<Type>> _handlers;
        List<Type> _eventTypes;

        public RabbitEventBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        public void Publish<T>(T @event) where T : Evento
        {

            var factory = new ConnectionFactory() { HostName = "rabbitServerWeb" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var eventName = @event.GetType().Name;

                    channel.QueueDeclare(eventName, false, false, false, null);
                    var message = JsonConvert.SerializeObject(@event);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", eventName, null, body);

                }

            }

        }

        public Task SendCommand<T>(T comando) where T : Comando
        {
            return _mediator.Send(comando);
        }

        public void Subscribe<T, TH>()
            where T : Evento
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var eventType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if (_handlers[eventName].Any(x => x.GetType() == eventType))
            {
                throw new ArgumentException($"Handler { eventType.Name } was registered by { eventName } ");
            }

            _handlers[eventName].Add(eventType);

            var factory = new ConnectionFactory()
            {
                HostName = "rabbitServerWeb",
                DispatchConsumersAsync = true
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, true, consumer);
            

        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                if (_handlers.ContainsKey(eventName))
                {
                    var sub = _handlers[eventName];
                    foreach (var item in sub)
                    {
                        var handler = Activator.CreateInstance(item);
                        if (handler == null)
                        {
                            continue;
                        }

                        var eventType = _eventTypes.SingleOrDefault(x => x.Name == eventName);
                        var eventDS = JsonConvert.DeserializeObject(message, eventType);

                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                        await (Task) concreteType.GetMethod("Handle").Invoke(handler, new object[] { eventDS });
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
