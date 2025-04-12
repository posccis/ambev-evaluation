using FluentValidation;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class DocumentValidator : AbstractValidator<string>
{
    public DocumentValidator()
    {
        RuleFor(document => document)
            .NotEmpty()
            .WithMessage("The document cannot be empty.")
            .MaximumLength(14)
            .WithMessage("The document cannot be longer than 14 characters.")
            .MinimumLength(11)
            .WithMessage("The document cannot be smaller than 11 characters.")
            .Must(IsValidDocument)
            .WithMessage("The provided document is not valid.");
    }

    public bool IsValidDocument(string document) 
    {
        document = new string(document.Where(char.IsDigit).ToArray());


        if (document.Length == 11) 
        {
            return IsValidCPF(document);
        }
        else if(document.Length == 14)
        {
            return IsValidCNPJ(document);
        }
        return false;
    }

    private bool IsValidCPF(string cpf)
    {
        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        var numbers = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        for (int j = 9; j < 11; j++)
        {
            int sum = 0;
            for (int i = 0; i < j; i++)
                sum += numbers[i] * ((j + 1) - i);

            int remainder = (sum * 10) % 11;
            if (remainder == 10) remainder = 0;

            if (numbers[j] != remainder)
                return false;
        }

        return true;
    }
    private bool IsValidCNPJ(string cnpj)
    {

        int[] multiplicator1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicator2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int[] digits = cnpj.Select(c => int.Parse(c.ToString())).ToArray();

        int sum1 = 0, sum2 = 0;

        for (int i = 0; i < 12; i++)
        {
            sum1 += digits[i] * multiplicator1[i];
            sum2 += digits[i] * multiplicator2[i];
        }

        int remainder1 = (sum1 % 11);
        remainder1 = remainder1 < 2 ? 0 : 11 - remainder1;

        sum2 += remainder1 * multiplicator2[12];
        int remainder2 = (sum2 % 11);
        remainder2 = remainder2 < 2 ? 0 : 11 - remainder2;

        return digits[12] == remainder1 && digits[13] == remainder2;

    }
}
