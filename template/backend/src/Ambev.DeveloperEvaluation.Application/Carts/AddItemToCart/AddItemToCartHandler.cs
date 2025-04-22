using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using OneOf.Types;

namespace Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart
{
    public class AddItemToCartHandler : IRequestHandler<AddItemToCartCommand, AddItemToCartResult>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddItemToCartHandler(ICartItemRepository cartItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<AddItemToCartResult> Handle(AddItemToCartCommand command, CancellationToken cancellationToken) 
        {
            var validator = new AddItemToCartValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var productToAdd = await _productRepository.GetByIdAsync(command.ProductId);

            if (productToAdd == null)
                throw new InvalidOperationException($"The product with ID {command.ProductId} do not exist.");

            var newCartItem = new CartItem().GenerateCartItem(productToAdd, command.Quantity, command.CartId);
            
            var result = await _cartItemRepository.CreateCartItemAsync(newCartItem, cancellationToken); 

            return _mapper.Map<AddItemToCartResult>(result);

        }
    }
}
