using EducationMicroserviceProject.Discount.API.Features.Discounts.GetDiscountByCode;
using EducationMicroserviceProject.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EducationMicroserviceProject.Discount.API.Features.Discounts.CreateDiscount
{
    public static class GetDiscountCommandEndpoint
    {
        public static RouteGroupBuilder GetDiscountGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{code:length(10)}",
                async (string code, IMediator mediator) =>
                    (await mediator.Send(new GetDiscountByCodeQuery(code))).ToGenericResult())
                 .WithName("GeteDiscountByCode")
                 .Produces<GetDiscountByCodeQueryResponse>(StatusCodes.Status200OK)
                 .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                 .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return group;
        }
    }
}
