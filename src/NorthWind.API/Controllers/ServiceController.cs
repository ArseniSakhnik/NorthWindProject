using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Core.Enums;
using NorthWindProject.Application.Features.Services.Command.LoadServiceDocumentTemplate;

namespace NorthWind.API.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpPost("load-template/{serviceId:int}")]
        public async Task<IActionResult> LoadTemplate(int serviceId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new LoadServiceDocumentTemplateCommand
            {
                ServicesRequestTypeId = (ServicesRequestTypeEnum) serviceId,
                File = Request.Form.Files.SingleOrDefault()
            }, cancellationToken));
        }
    }
}