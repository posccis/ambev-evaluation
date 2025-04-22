using Ambev.DeveloperEvaluation.WebApi.Features.Cart.AddItemToCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class AddItemToCartRequestValidator : AbstractValidator<AddItemToCartRequest>
    {
        public AddItemToCartRequestValidator()
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
