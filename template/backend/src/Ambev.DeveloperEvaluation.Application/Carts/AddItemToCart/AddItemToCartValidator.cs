using Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart
{
    public class AddItemToCartValidator : AbstractValidator<AddItemToCartCommand>
    {
        public AddItemToCartValidator()
        {
            RuleFor(cart => cart.CartId)
                .Empty()
                .Null()
                .WithMessage("The cart's id is required.");

            RuleFor(cart => cart.ProductId)
                .Empty()
                .Null()
                .WithMessage("The product's id is required.");

            RuleFor(cart => cart.Quantity)
                .GreaterThanOrEqualTo(0)
                .Empty()
                .Null()
                .WithMessage("The product's quantity is required.");
        }
    
    }
}
