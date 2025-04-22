using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Shopping.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public Guid CartId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShippingAddressId { get; set; }
        public int BranchId { get; set; }
        public PaymentMethodBase PaymentMethod{ get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new CreateOrderValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
