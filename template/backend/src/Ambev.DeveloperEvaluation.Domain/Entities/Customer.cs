using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;


namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer : BaseEntity, ICustomer
    {
        public Guid Id { get; set; }
        public string FullName { get => ( FirstName + ' ' + LastName); }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Document { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Order> Orders { get; set; } = new List<Order>();

        public ValidationResultDetail Validate()
        {
            var validator = new CustomerValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
