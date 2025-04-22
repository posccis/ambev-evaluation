using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Messaging.Interfaces
{
    public interface IPublisherBus
    {
        Task<TResponse> SendAsync<TRequest, TResponse>(TRequest evento, CancellationToken cancellationToken = default) 
            where TRequest : class
            where TResponse : class;

    }
}
