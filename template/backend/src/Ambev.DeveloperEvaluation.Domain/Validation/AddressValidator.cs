using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(ad => ad.CustomerId)
            .NotEmpty()
            .WithMessage("The customer ID must be informed.");

        RuleFor(ad => ad.Number)
            .GreaterThan(0).WithMessage("Number must be at least 1.");

        RuleFor(ad => ad.Street)
        .NotEmpty()
        .MinimumLength(3).WithMessage("The name of the street must be at least 3 characters long.")
        .MaximumLength(50).WithMessage("The name of the street must be less or equal to 50 characters long.");
        
        RuleFor(ad => ad.Neighborhood)
        .NotEmpty()
        .MinimumLength(3).WithMessage("The name of the neighborhood must be at least 3 characters long.")
        .MaximumLength(50).WithMessage("The name of the neighborhood must be less or equal to 50 characters long.");

        RuleFor(ad => ad.State)
        .IsInEnum()
        .WithMessage("State invalid.");
                        
        RuleFor(ad => ad.City)
        .NotEmpty()
        .MinimumLength(3).WithMessage("The name of the city must be at least 3 characters long.")
        .MaximumLength(50).WithMessage("The name of the city must be less or equal to 50 characters long.");
       
        RuleFor(ad => ad.ZipCode)
        .Length(7).WithMessage("Zip code must be 7 digits long.");
        
    }
}
