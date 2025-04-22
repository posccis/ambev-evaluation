using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartResult, CreateCartResponse>();
            CreateMap<CreateCartRequest, CreateCartRequest>();
        }
    }
}
