using AutoMapper;
using EducationMicroserviceProject.Catalog.API.Features.Categories.Dtos;

namespace EducationMicroserviceProject.Catalog.API.Features.Categories
{
    public class CategoryMapping :Profile
    {
        public CategoryMapping()
        { 
        CreateMap<CategoryEntity,CategoryDto>().ReverseMap();
        }    
    }
}
