using Ambev.DeveloperEvaluation.Messaging.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.Messaging.Publishers
{
    public class Publisher : IPublisherBus
    {
        private readonly IServiceProvider _provider;

        public Publisher(IServiceProvider provider)
        {
            _provider = provider;
        }
        public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest evento, CancellationToken cancellationToken = default)
            where TRequest : class
            where TResponse : class
        {
            var client = _provider.GetRequiredService<IRequestClient<TRequest>>();
            var response = await client.GetResponse<TResponse>(evento);
            return response.Message;
        }
    }
}
