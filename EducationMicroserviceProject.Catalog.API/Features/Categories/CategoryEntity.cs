using EducationMicroserviceProject.Catalog.API.Features.Courses;
using EducationMicroserviceProject.Catalog.API.Repositories;

namespace EducationMicroserviceProject.Catalog.API.Features.Categories
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<CourseEntity>? Courses { get; set; }
    }
}
