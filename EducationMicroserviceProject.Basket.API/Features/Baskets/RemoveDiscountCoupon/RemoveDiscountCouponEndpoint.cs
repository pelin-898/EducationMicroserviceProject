using AutoMapper;
using EducationMicroserviceProject.Basket.API.Const;
using EducationMicroserviceProject.Basket.API.Data;
using EducationMicroserviceProject.Basket.API.Dto;
using EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem;
using EducationMicroserviceProject.Shared;
using EducationMicroserviceProject.Shared.Extensions;
using EducationMicroserviceProject.Shared.Filters;
using EducationMicroserviceProject.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.RemoveDiscountCoupon
{
    public record RemoveDiscountCouponCommand() : IRequestByServiceResult;

    public class RemoveDiscountCouponCommandHandler(BasketService basketService) :IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

            if (string.IsNullOrEmpty(basketAsJson))
            {
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);
            }

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);
            basket!.ClearDiscount();

            await basketService.SaveBasketToCacheAsync(basket, cancellationToken);

            return ServiceResult.SuccessAsNocontent();
        }
    }

    public static class RemoveDiscountCouponEndpoint
    {
        public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/rewmove-discount-coupon",
                async (IMediator mediatr) =>
                (await mediatr.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
            .WithName("RemoveDiscountCoupon");

            return group;
        }
    }
}
