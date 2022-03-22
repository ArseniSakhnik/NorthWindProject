using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Services.Command.LoadServiceDocumentTemplate;

namespace NorthWind.API.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpPost("load-template/{serviceId:int}")]
        public async Task<IActionResult> LoadTemplate(int serviceId, CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new LoadServiceDocumentTemplateCommand
            {
                ServiceId = serviceId,
                File = Request.Form.Files.SingleOrDefault()
            }, cancellationToken));

    }
}