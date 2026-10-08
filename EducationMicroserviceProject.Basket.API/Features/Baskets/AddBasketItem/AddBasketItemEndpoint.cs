using EducationMicroserviceProject.Shared.Extensions;
using EducationMicroserviceProject.Shared.Filters;
using MediatR;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/item", 
                async (AddBasketItemCommand command, IMediator mediatr) =>
                (await mediatr.Send(command)).ToGenericResult())
            .WithName("AddBasketItem")       
            .AddEndpointFilter<ValidationFilter<AddBasketItemCommandValidator>>();

            return group;
        }
    }
}
