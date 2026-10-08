using EducationMicroserviceProject.Discount.API.Repositories;
using EducationMicroserviceProject.Shared.Services;

namespace EducationMicroserviceProject.Discount.API.Features.Discounts.CreateDiscount
{
    public class CreateDiscountCommandHandler(AppDbContext context, IIdentityService identityService) : IRequestHandler<CreateDiscountCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var hasCodeForUser = await context.Discounts.AnyAsync(x => x.UserId == request.UserId && x.Code == request.Code ,cancellationToken);
            
            if(hasCodeForUser)
            {
                return ServiceResult.Error("Discount code already exists for this user", HttpStatusCode.BadRequest);
            }

            var discount = new DiscountEntity()
            {
                Id = NewId.NextSequentialGuid(),
                Code = request.Code,
                Expired = request.Expired,
                Rate = request.Rate,
                UserId = request.UserId,
                Created = DateTime.Now
            };

            await context.Discounts.AddAsync(discount, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNocontent();

        }
    }
}
