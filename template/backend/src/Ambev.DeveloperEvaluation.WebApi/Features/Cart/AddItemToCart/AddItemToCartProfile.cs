using Ambev.DeveloperEvaluation.WebApi.Features.Cart.AddItemToCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class AddItemToCartProfile : Profile
    {
        public AddItemToCartProfile()
        {
            CreateMap<AddItemToCartResult, AddItemToCartResponse>();
            CreateMap<AddItemToCartRequest, Application.Carts.AddItemToCart.AddItemToCartCommand>();
        }
    }
}
