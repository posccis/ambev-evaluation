using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart
{
    public class AddItemToCartProfile : Profile
    {
        public AddItemToCartProfile()
        {
            CreateMap<CartItem, AddItemToCartResult>();

        }

    }
}
