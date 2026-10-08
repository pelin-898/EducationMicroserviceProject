using EducationMicroserviceProject.Basket.API.Const;
using EducationMicroserviceProject.Basket.API.Dto;
using EducationMicroserviceProject.Shared;
using EducationMicroserviceProject.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public class ApplyDiscountCouponHandler(BasketService basketService) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
        {    
            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

            if (string.IsNullOrEmpty(basketAsJson))
            {
                return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);
            }

            var basket =JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

            if(!basket.Items.Any())
            {
                return ServiceResult<BasketDto>.Error("Basket item not found", HttpStatusCode.NotFound);
            }

            basket.ApplyNewDiscount(request.Coupon, request.DiscountRate);

            await basketService.SaveBasketToCacheAsync(basket, cancellationToken);
            
            return ServiceResult.SuccessAsNocontent();
        }
    }
}
