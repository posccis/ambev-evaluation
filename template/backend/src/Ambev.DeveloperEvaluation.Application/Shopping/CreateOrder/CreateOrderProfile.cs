using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Shopping.CreateOrder
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<Order, CreateOrderResult>();
            CreateMap<Order, OrderCreatedEvent>();
            CreateMap<CartItem, OrderItem>();

        }

    }
}
