using Ambev.DeveloperEvaluation.Application.Carts.AddItemToCart;
using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Shopping.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Shopping.GetOrder;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.AddItemToCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Order.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Shopping.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Shopping.GetOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping
{
    /// <summary>
    /// Controller for managing carts operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ShoppingController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public ShoppingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="request">The object containg the customer id.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateOrderCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateOrderResponse>
            {
                Success = true,
                Message = "Order created successfully",
                Data = _mapper.Map<CreateOrderResponse>(response)
            });
        }

        /// <summary>
        /// Returns all orders in the database
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The list of all orders</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<List<GetOrderResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery();
            var response = await _mediator.Send(query, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<GetOrderResponse>
            {
                Success = true,
                Message = "Order created successfully",
                Data = _mapper.Map<GetOrderResponse>(response)
            });
        }

    }
}
