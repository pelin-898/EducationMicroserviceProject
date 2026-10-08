using Asp.Versioning.Builder;
using EducationMicroserviceProject.Catalog.API.Features.Categories.Create;
using EducationMicroserviceProject.Catalog.API.Features.Categories.GetById;
using EducationMicroserviceProject.Catalog.API.Features.Categories.NewFolder;
using System.Runtime.CompilerServices;
namespace EducationMicroserviceProject.Catalog.API.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app,ApiVersionSet apiVersionSet)
        {
            //app.MapGroup("api/categories").CreateCategoryGroupItemEndpoint().RequireAuthorization();
            app.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
                .WithApiVersionSet(apiVersionSet)
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetByIdCategoryGroupItemEndpoint();
        }
    }
}
