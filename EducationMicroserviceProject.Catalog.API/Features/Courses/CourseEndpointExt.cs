using Asp.Versioning.Builder;
using EducationMicroserviceProject.Catalog.API.Features.Categories.Create;
using EducationMicroserviceProject.Catalog.API.Features.Courses.Create;
using EducationMicroserviceProject.Catalog.API.Features.Courses.Delete;
using EducationMicroserviceProject.Catalog.API.Features.Courses.GetAll;
using EducationMicroserviceProject.Catalog.API.Features.Courses.GetById;
using EducationMicroserviceProject.Catalog.API.Features.Courses.Update;

namespace EducationMicroserviceProject.Catalog.API.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses")
                .WithApiVersionSet(apiVersionSet)
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GeByUserIdCourseCourseGroupItemEndpoint();
        }
    }
}
