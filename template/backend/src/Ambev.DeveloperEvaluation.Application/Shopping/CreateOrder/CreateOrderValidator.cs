using Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart;
using Ambev.DeveloperEvaluation.Application.Shopping.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Shopping.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty().WithMessage("CartId is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.ShippingAddressId)
                .NotEmpty().WithMessage("ShippingAddressId is required.");

            RuleFor(x => x.BranchId)
                .GreaterThan(0).WithMessage("BranchId must be greater than 0.");

            RuleFor(x => x.PaymentMethod)
                .Null()
                .WithMessage("Payment method is required.");

            RuleFor(x => x.PaymentMethod.TotalCharge)
                .GreaterThan(0)
                .WithMessage("The value of the payment method is required.")
                .When(x => x.PaymentMethod != null);
        }
    }
}
