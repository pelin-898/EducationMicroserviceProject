using EducationMicroserviceProject.Shared;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets.AddBasketItem
{
    public record AddBasketItemCommand(Guid CourseId,string CourseName,decimal CoursePrice,string? ImageUrl) :IRequestByServiceResult
    {
    }
}
