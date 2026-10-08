using EducationMicroserviceProject.Catalog.API.Features.Courses.Create;
using EducationMicroserviceProject.Catalog.API.Features.Courses.Dtos;

namespace EducationMicroserviceProject.Catalog.API.Features.Courses
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<CreateCourseCommand, CourseEntity>();
            CreateMap<CourseEntity, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

        }
    }
}
