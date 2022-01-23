using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.UploadBasicServices.UploadAssenizatorService;

namespace NorthWind.API.Controllers
{
    public class ServicesController : ApiController
    {
        [HttpPost("upload-assenizator-service")]
        public async Task<IActionResult> UploadAssenizatorService(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new UploadAssenizatorServiceCommand
            {
                File = Request.Form.Files.SingleOrDefault()
            }, cancellationToken));
    }
}