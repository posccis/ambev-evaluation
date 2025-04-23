using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Common;
using AutoMapper;
using FluentValidation;
using MediatR;
using OneOf.Types;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken) 
        {
            var validator = new CreateCartValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingCart = await _cartRepository.GetByCustomerIdAsync(command.CustomerId);

            if (existingCart != null)
                throw new InvalidOperationException($"User with email {command.CustomerId} already exists");

            var newGeneratedCart = new Cart().GenerateNewCart(command.CustomerId);
            
            var newCart = await _cartRepository.CreateAsync(newGeneratedCart);

            var result = _mapper.Map<CreateCartResult>(newCart);

            await _unitOfWork.CommitAsync();

            return result;

        }
    }
}
