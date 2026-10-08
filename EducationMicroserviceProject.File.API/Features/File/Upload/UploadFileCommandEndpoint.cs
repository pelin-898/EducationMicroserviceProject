using EducationMicroserviceProject.File.API.Features.File.Upload;
using EducationMicroserviceProject.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationMicroserviceProject.File.API.Features.File.Upload
{
    public static class UploadFileCommandEndpoint
    {
        public static RouteGroupBuilder UploadFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/",
                async (IFormFile file, IMediator mediator) =>
                    (await mediator.Send(new UploadFileCommand(file))).ToGenericResult())
                 .WithName("upload")
                 .Produces<Guid>(StatusCodes.Status201Created)
                 .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                 .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError).DisableAntiforgery();       

            return group;
        }
    }
}
