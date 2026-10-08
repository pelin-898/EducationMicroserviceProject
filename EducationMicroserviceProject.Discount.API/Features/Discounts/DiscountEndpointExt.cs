using Asp.Versioning.Builder;
using EducationMicroserviceProject.Discount.API.Features.Discounts.CreateDiscount;

namespace EducationMicroserviceProject.Discount.API.Features.Discounts
{
    public static class DiscountEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/discounts").WithTags("Discounts")
                .WithApiVersionSet(apiVersionSet)
                .CreateDiscountGroupItemEndpoint()
                .GetDiscountGroupItemEndpoint();
        }
    }
}
