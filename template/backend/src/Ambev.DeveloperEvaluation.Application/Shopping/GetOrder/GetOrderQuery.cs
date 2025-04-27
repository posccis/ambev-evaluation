using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart;
using Ambev.DeveloperEvaluation.Shopping.GetOrder;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Shopping.GetOrder
{
    public class GetOrderQuery : IRequest<GetOrderResults>
    {

    }
}
