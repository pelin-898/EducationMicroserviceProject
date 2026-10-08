using EducationMicroserviceProject.Basket.API.Const;
using EducationMicroserviceProject.Basket.API.Dto;
using EducationMicroserviceProject.Shared;
using EducationMicroserviceProject.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService,BasketService basketService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);
            if (basketAsJson is null)
            {
                return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);
            }

            var currentBasket = System.Text.Json.JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

            var basketItemToDelete = currentBasket.Items.FirstOrDefault(x => x.Id == request.Id);

            if (basketItemToDelete is null)
            {
              return ServiceResult.Error("Basket item not found", HttpStatusCode.NotFound);
            }

            currentBasket.Items.Remove(basketItemToDelete);

            await basketService.SaveBasketToCacheAsync(currentBasket, cancellationToken);

            return ServiceResult.SuccessAsNocontent();
        }
    }
}
