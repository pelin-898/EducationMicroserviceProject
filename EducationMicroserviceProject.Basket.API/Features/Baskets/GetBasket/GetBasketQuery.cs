using EducationMicroserviceProject.Basket.API.Dto;
using EducationMicroserviceProject.Shared;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.GetBasket
{
    public record GetBasketQuery :IRequestByServiceResult<BasketDto>;

}
