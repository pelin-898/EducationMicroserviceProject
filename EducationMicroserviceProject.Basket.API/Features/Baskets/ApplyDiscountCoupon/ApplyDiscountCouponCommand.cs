using EducationMicroserviceProject.Shared;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.ApplyDiscountCoupon
{
    public record ApplyDiscountCouponCommand(string Coupon,float DiscountRate) : IRequestByServiceResult;  
}
