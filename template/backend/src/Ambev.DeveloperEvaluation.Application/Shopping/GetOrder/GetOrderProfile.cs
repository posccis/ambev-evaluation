using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart;
using Ambev.DeveloperEvaluation.Shopping.GetOrder;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Shopping.CreateOrder
{
    public class GetOrderProfile : Profile
    {
        public GetOrderProfile()
        {
            CreateMap<Order, GetOrderResult>();


        }

    }
}
