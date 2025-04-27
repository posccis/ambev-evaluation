using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Shopping.GetOrder
{
    public class GetOrderResponse
    {
        public List<GetOrderResult> Result { get; set; }
    }
}
