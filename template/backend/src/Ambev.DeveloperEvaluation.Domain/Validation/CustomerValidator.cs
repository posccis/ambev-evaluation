using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Email).SetValidator(new EmailValidator());

        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Firstname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("cname cannot be longer than 50 characters.");

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Lastname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Lastname cannot be longer than 50 characters.");

        RuleFor(c => c.Password).SetValidator(new PasswordValidator());
        
        RuleFor(c => c.PhoneNumber)
            .Matches(@"^\+[1-9]\d{10,14}$")
            .WithMessage("Phone number must start with '+' followed by 11-15 digits.");

        RuleFor(c => c.Document).SetValidator()
        
        RuleFor(c => c.Role)
            .NotEqual(cRole.None)
            .WithMessage("c role cannot be None.");
    }
}
