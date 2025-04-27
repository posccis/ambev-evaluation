using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Messaging.Interfaces;
using Ambev.DeveloperEvaluation.ORM.Common;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart;
using Ambev.DeveloperEvaluation.Shopping.GetOrder;
using AutoMapper;
using FluentValidation;
using MediatR;
using OneOf.Types;

namespace Ambev.DeveloperEvaluation.Application.Shopping.GetOrder
{
    public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderResults>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetOrderResults> Handle(GetOrderQuery query, CancellationToken cancellationToken) 
        {
            GetOrderResults result = new();
            var orders = await _orderRepository.GetOrdersAsync();

            result.Result.AddRange(_mapper.Map<List<GetOrderResult>>(orders));

            return result;

        }

    }
}
