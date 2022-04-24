using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Cars.Query;

namespace NorthWind.API.Controllers
{
    public class CarsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCars(CancellationToken cancellationToken)
            => Ok(await Mediator.Send(new GetCarsQuery(), cancellationToken));
    }
}