using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthWindProject.Application.Features.Purchase.Command;

namespace NorthWind.API.Controllers
{
    public class PurchaseController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> SendPurchase(SendPurchaseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}