using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Order entity operations
/// </summary>
public interface IOrderRepository
{

    /// <summary>
    /// Creates a Order 
    /// </summary>
    /// <param name="order">The object of the order to be created.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    void CreateOrderAsync(Order order, CancellationToken cancellationToken = default);
    Task<List<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);

}
