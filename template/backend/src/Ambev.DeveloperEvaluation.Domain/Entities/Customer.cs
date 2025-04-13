using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime CreatedOn { get => DateTime.Now; }
        public DateTime UpdatedOn { get => DateTime.Now; }
        public string Password { get; set; }
        public bool Active { get; set; }
        List<Address> Addresses { get; set; }
        List<Order> Orders { get; set; }

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
