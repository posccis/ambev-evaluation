using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface IProduct
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        int StockQuantity { get; set; }
        string SKU { get; set; }

        Guid CategoryId { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }

        string ImageUrl { get; set; }
        decimal? DiscountPrice { get; set; }
    }
}
