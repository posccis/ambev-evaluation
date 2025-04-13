using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(od => od.CustomerId)
            .NotEmpty()
            .WithMessage("The customer ID must be informed.");

        RuleFor(od => od.ShippingAddress)
        .NotNull()
        .WithMessage("The shipping address is cannot be null.");

        RuleFor(od => od.Items)
        .NotNull()
        .NotEmpty()
        .WithMessage("The order needs at least one item.");

        RuleFor(od => od.PaymentMethod)
        .NotNull()
        .WithMessage("The order needs a valid payment method.");

        
    }
}
