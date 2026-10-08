using EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem;
using EducationMicroserviceProject.Shared.Extensions;
using EducationMicroserviceProject.Shared.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.DeleteBasketItem
{
    public static class DeleteBasketItemCommandEndpoint
    {
        public static RouteGroupBuilder DeleteBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("/item/{id:guid}",
                async (Guid id, IMediator mediatr) =>
                (await mediatr.Send(new DeleteBasketItemCommand(id))).ToGenericResult())
            .WithName("DeleteBasketItem");

            return group;
        }
    }
}
