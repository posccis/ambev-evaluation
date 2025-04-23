using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping.CreateOrder
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<Domain.Entities.Order, OrderCreatedEvent>();
            CreateMap<Domain.Entities.Order, CreateOrderResult >();
        }
    }
}
