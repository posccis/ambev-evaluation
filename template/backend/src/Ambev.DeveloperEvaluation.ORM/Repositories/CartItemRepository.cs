using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class CartItemRepository : ICartItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of CartItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CartItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new CartItem
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task CreateCartItemAsync(CartItem item, CancellationToken cancellationToken = default)
    {
        await _context.CartItems.AddAsync(item);
    }

}
