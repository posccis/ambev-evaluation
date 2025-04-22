using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Messaging.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Messaging.Consumers
{
    public class Consumer : IConsumer
    {
        public void HandleAsync(ExecutePaymentEvent evento, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("_________Payment Executed");
        }
        public Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest evento, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }
    }
}
