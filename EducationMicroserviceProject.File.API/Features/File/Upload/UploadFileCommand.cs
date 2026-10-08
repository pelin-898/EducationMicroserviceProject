using EducationMicroserviceProject.Shared;

namespace EducationMicroserviceProject.File.API.Features.File.Upload
{
    public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;

}
