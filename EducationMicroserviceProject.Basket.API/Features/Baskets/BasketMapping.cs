using AutoMapper;
using EducationMicroserviceProject.Basket.API.Data;
using EducationMicroserviceProject.Basket.API.Dto;

namespace EducationMicroserviceProject.Basket.API.Features.Baskets
{
    public class BasketMapping :Profile
    {
        public BasketMapping()
        {
            CreateMap<BasketDto, Data.Basket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();

        }

    }
}
