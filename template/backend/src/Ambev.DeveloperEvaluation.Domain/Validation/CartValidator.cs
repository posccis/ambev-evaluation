using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CartValidator : AbstractValidator<Cart>
    {
        public CartValidator()
        {
            RuleFor(c => c.Items)
                .NotEmpty()
                .When(i => i.Items.Any(it => it.Quantity > 20))
                .WithMessage("Its not allowed to buy more than 20 units of each product.");
        }
    }
}
