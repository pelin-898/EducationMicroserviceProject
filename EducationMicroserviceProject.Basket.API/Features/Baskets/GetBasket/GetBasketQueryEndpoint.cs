using EducationMicroserviceProject.Shared.Extensions;
using MediatR;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.GetBasket
{
    public static class GetBasketQueryEndpoint
    {
        public static RouteGroupBuilder GetBasketGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/user",
                async (IMediator mediatr) =>
                (await mediatr.Send(new GetBasketQuery())).ToGenericResult())
            .WithName("GetBasket");

            return group;
        }
    }
}
