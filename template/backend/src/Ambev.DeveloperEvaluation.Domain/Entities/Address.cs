using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Address : BaseEntity, IAddress
    {
        public Guid Id { get; set; }
        public string CustomerId { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public AddressState State { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string ReferencePoint { get; set; }

        public Customer customer { get; set; }


        public ValidationResultDetail Validate()
        {
            var validator = new AddressValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

    }
}
