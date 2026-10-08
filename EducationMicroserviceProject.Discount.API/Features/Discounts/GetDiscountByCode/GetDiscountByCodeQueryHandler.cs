using EducationMicroserviceProject.Discount.API.Repositories;
using EducationMicroserviceProject.Shared.Services;

namespace EducationMicroserviceProject.Discount.API.Features.Discounts.GetDiscountByCode
{
    public class GetDiscountByCodeQueryHandler(AppDbContext context,IIdentityService identityService) : IRequestHandler<GetDiscountByCodeQuery, ServiceResult<GetDiscountByCodeQueryResponse>>
    {
        public async Task<ServiceResult<GetDiscountByCodeQueryResponse>> Handle(GetDiscountByCodeQuery request, CancellationToken cancellationToken)
        {
            var hasDiscount =await context.Discounts.SingleOrDefaultAsync(x => x.Code == request.Code,cancellationToken);
            
            if (hasDiscount == null)
            {
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount not Found", HttpStatusCode.NotFound);
            }

            if(hasDiscount.Expired < DateTime.Now)
            {
                return ServiceResult<GetDiscountByCodeQueryResponse>.Error("Discount is Expired", HttpStatusCode.BadRequest);
            }

            return ServiceResult<GetDiscountByCodeQueryResponse>.SuccessAsOk(new GetDiscountByCodeQueryResponse(hasDiscount.Code, hasDiscount.Rate));
        }
    }
}
