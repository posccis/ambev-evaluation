using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of CartItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public OrderRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Order.
    /// </summary>
    /// <param name="order">The object of the order to be created.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The order if created </returns>
    public void CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        _context.Orders.Add(order);
    }

}
