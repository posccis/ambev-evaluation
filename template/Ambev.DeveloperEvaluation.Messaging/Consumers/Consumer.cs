using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Messaging.Interfaces;
using Ambev.DeveloperEvaluation.NoSql.Context;


namespace Ambev.DeveloperEvaluation.Messaging.Consumers
{
    public class Consumer : IConsumerBus
    {
        private readonly NoSqlContext _context;
        public Consumer(NoSqlContext context)
        {
            _context = context;
        }
        public void HandleAsync(ExecutePaymentEvent evento, CancellationToken cancellationToken = default)
        {
            _context.Notifications.Add(new() { Id= Guid.NewGuid(), OrderId = evento.OrderId, Body = OrderStatus.AwaitingPayment.ToString()});
        }
        public void HandleAsync(OrderCreatedEvent evento, CancellationToken cancellationToken = default)
        {
            _context.Notifications.Add(new() { Id = Guid.NewGuid(), OrderId = evento.OrderId, Body = $"Pedido realizado em {evento.CreatedOn.ToShortDateString}!###### Valor total do pedido: R${evento.OrderId}" });
        }
        public Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest evento, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }
    }
}
