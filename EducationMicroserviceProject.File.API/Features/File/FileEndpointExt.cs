using Asp.Versioning.Builder;
using EducationMicroserviceProject.File.API.Features.File.Delete;
using EducationMicroserviceProject.File.API.Features.File.Upload;

namespace EducationMicroserviceProject.File.API.Features.File
{
    public static class FileEndpointExt
    {
        public static void AddFileGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/files").WithTags("files").WithApiVersionSet(apiVersionSet)
              .UploadFileGroupItemEndpoint().DeleteFileGroupItemEndpoint();
        }
    }
}
