using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidator()
        {
            RuleFor(cart => cart.CustomerId)
                .Empty()
                .Null()
                .WithMessage("The customer's id is required.");
            RuleFor(cart => cart.CustomerId)
                .Empty()
                .Null()
                .WithMessage("The customer's id is required.");
        }
    }
}
