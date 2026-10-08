namespace EducationMicroserviceProject.Catalog.API.Features.Courses.Dtos
{
    public class FeatureDto
    {
        public int Duration { get; set; }
        public string EducatorFullName { get; set; } = default!;
        public double Rating { get; set; }
    }
}
