using EducationMicroserviceProject.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EducationMicroserviceProject.Discount.API.Features.Discounts.CreateDiscount
{
    public static class CreateDiscountCommandEndpoint
    {
        public static RouteGroupBuilder CreateDiscountGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (CreateDiscountCommand command, IMediator mediator) =>
                    (await mediator.Send(command)).ToGenericResult())
                 .WithName("CreateDiscount")
                 .Produces<Guid>(StatusCodes.Status201Created)
                 .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                 .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
                 .AddEndpointFilter<ValidationFilter<CreateDiscountCommandValidator>>();

            return group;
        }
    }
}
