using Ambev.DeveloperEvaluation.WebApi.Features.Order.CreateOrder;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping.CreateOrder
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty().WithMessage("CartId is required.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.ShippingAddressId)
                .NotEmpty().WithMessage("ShippingAddressId is required.");

            RuleFor(x => x.BranchId)
                .GreaterThan(0).WithMessage("BranchId must be greater than 0.");
        }
    }
}
