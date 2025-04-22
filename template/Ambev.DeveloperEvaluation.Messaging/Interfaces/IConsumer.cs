using Ambev.DeveloperEvaluation.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Messaging.Interfaces
{
    public interface IConsumer
    {
        Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest evento, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class;
        void HandleAsync(ExecutePaymentEvent evento, CancellationToken cancellationToken = default);
    }
}
