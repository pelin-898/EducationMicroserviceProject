using EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem;
using EducationMicroserviceProject.Shared.Extensions;
using EducationMicroserviceProject.Shared.Filters;
using MediatR;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public static class ApplyDiscountCouponEndpoint
    {
        public static RouteGroupBuilder ApplyDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/apply-discount-coupon",
                async (ApplyDiscountCouponCommand command, IMediator mediatr) =>
                (await mediatr.Send(command)).ToGenericResult())
            .WithName("ApplyDiscountRate")
            .AddEndpointFilter<ValidationFilter<ApplyDiscountCouponCommandValidator>>();

            return group;
        }
    }
}
