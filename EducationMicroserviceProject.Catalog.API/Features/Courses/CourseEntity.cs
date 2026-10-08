using EducationMicroserviceProject.Catalog.API.Features.Categories;
using EducationMicroserviceProject.Catalog.API.Repositories;

namespace EducationMicroserviceProject.Catalog.API.Features.Courses
{
    public class CourseEntity :BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Created { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = default!;
        public Feature Feature { get; set; } = default!;

    }
}
