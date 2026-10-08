using EducationMicroserviceProject.Basket.API.Const;
using EducationMicroserviceProject.Basket.API.Data;
using EducationMicroserviceProject.Basket.API.Dto;
using EducationMicroserviceProject.Shared;
using EducationMicroserviceProject.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandHandler(IIdentityService identityService,BasketService basketService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

            Data.Basket? currentBasket;

            var newBasketItem = new BasketItem(request.CourseId, request.CourseName, request.ImageUrl, request.CoursePrice, null);

            if (string.IsNullOrEmpty(basketAsJson))
            {
                currentBasket = new Data.Basket(identityService.GetUserId, [newBasketItem]);
                await basketService.SaveBasketToCacheAsync(currentBasket, cancellationToken);
                return ServiceResult.SuccessAsNocontent();
            }

            currentBasket = System.Text.Json.JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

            var existBasketItem = currentBasket.Items.FirstOrDefault(x => x.Id == request.CourseId);

            if (existBasketItem is not null)
            {
                currentBasket.Items.Remove(existBasketItem);
            }

            currentBasket.Items.Add(newBasketItem);

            currentBasket.ApplyAvailableDiscount();

            await basketService.SaveBasketToCacheAsync(currentBasket, cancellationToken);

            return ServiceResult.SuccessAsNocontent();

        }
  
    }
}
