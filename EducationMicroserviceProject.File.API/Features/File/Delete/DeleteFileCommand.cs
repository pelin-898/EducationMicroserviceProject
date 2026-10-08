using EducationMicroserviceProject.Shared;

namespace EducationMicroserviceProject.File.API.Features.File.Delete
{
    public record DeleteFileCommand(string FileName) : IRequestByServiceResult;
}
