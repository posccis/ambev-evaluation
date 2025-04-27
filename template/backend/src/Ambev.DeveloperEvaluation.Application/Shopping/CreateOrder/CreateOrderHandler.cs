using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Messaging.Interfaces;
using Ambev.DeveloperEvaluation.ORM.Common;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder;
using Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart;
using AutoMapper;
using FluentValidation;
using MediatR;
using OneOf.Types;

namespace Ambev.DeveloperEvaluation.Application.Shopping.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IPublisherBus _publisher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrderRepository orderRepository, ICartRepository cartRepository, IProductRepository productRepository, IMapper mapper, IPublisherBus publisher, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _publisher = publisher;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken) 
        {
            var validator = new CreateOrderValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cartOrder = await _cartRepository.GetByIdAsync(command.CartId);

            if (cartOrder == null)
                throw new InvalidOperationException($"The cart with ID {command.CartId} does not exist.");

            var cartOrderValidate = cartOrder.Validate();

            if (!cartOrderValidate.IsValid)
                throw new InvalidOperationException(cartOrderValidate.Errors.First().Error);

            var order = new Order(command.CustomerId, command.BranchId, command.ShippingAddressId);

            var orderItems = _mapper.Map<List<OrderItem>>(cartOrder.Items);
            order.AddOrderItems(orderItems);
            _orderRepository.CreateOrderAsync(order);

            var paymentEvent = new ExecutePaymentEvent(command.PaymentMethod, order.Id);
            await _publisher.SendAsync<ExecutePaymentEvent, string>(paymentEvent);

            await _unitOfWork.CommitAsync();

            var orderCreated = _mapper.Map<OrderCreatedEvent>(order);
            await _publisher.SendAsync<OrderCreatedEvent, string>(orderCreated);

            return _mapper.Map<CreateOrderResult>(order);

        }

    }
}
