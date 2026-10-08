using EducationMicroserviceProject.Shared;
using MediatR;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace EducationMicroserviceProject.File.API.Features.File.Upload
{
    public class UploadFileCommandHandler(IFileProvider fileProvider) : IRequestHandler<UploadFileCommand, ServiceResult<UploadFileCommandResponse>>
    {
        public async Task<ServiceResult<UploadFileCommandResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            if (request.File.Length == 0)
            {
                return ServiceResult<UploadFileCommandResponse>.Error("File is empty", HttpStatusCode.BadRequest);
            }

            var newFileName = $"{Guid.NewGuid()}_{Path.GetExtension(request.File.FileName)}"; //.jpg

            var uploadPath = Path.Combine(fileProvider.GetFileInfo("files").PhysicalPath!,newFileName);
            
            await using var stream = new FileStream(uploadPath, FileMode.Create);

            await request.File.CopyToAsync(stream, cancellationToken);

            var response=new UploadFileCommandResponse(newFileName, $"files/{newFileName}", request.File.FileName);

            return ServiceResult<UploadFileCommandResponse>.SuccessAsCreated(response,response.FilePath);

        }
    }

}
