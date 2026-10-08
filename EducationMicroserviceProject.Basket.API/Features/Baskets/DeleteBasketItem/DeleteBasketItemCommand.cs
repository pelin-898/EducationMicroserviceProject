using EducationMicroserviceProject.Shared;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.DeleteBasketItem
{
    public record DeleteBasketItemCommand(Guid Id) :IRequestByServiceResult;
}
