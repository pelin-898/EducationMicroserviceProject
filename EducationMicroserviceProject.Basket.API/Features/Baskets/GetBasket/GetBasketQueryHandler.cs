using AutoMapper;
using EducationMicroserviceProject.Basket.API.Const;
using EducationMicroserviceProject.Basket.API.Dto;
using EducationMicroserviceProject.Shared;
using EducationMicroserviceProject.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.GetBasket
{
    public class GetBasketQueryHandler(BasketService basketService,IMapper mapper) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);
            
            if(string.IsNullOrEmpty(basketAsJson))
            {
                return ServiceResult<BasketDto>.Error("Basket not found",HttpStatusCode.NotFound);
            }

            var basket= JsonSerializer.Deserialize<BasketDto>(basketAsJson);

            var basketDto= mapper.Map<BasketDto>(basket);

            return ServiceResult<BasketDto>.SuccessAsOk(basketDto);
        }
    }
}
