using Asp.Versioning.Builder;
using EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem;
using EducationMicroserviceProject.Basket.API.Features.Baskets.ApplyDiscountCoupon;
using EducationMicroserviceProject.Basket.API.Features.Baskets.DeleteBasketItem;
using EducationMicroserviceProject.Basket.API.Features.Baskets.GetBasket;
using EducationMicroserviceProject.Basket.API.Features.Baskets.RemoveDiscountCoupon;

namespace EducationMicroserviceProject.Basket.API.Features
{
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketGroupItemEndpoint()
                .ApplyDiscountCouponGroupItemEndpoint()
                .RemoveDiscountCouponGroupItemEndpoint();
        }
    }
}
