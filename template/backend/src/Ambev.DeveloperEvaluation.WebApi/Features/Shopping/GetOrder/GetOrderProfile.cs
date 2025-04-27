using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping.GetOrder
{
    public class GetOrderProfile : Profile
    {
        public GetOrderProfile()
        {
            CreateMap<GetOrderResults, GetOrderResponse>();
            CreateMap<Domain.Entities.Order, GetOrderResult>();
        }
    }
}
