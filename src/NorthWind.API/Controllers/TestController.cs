using Microsoft.AspNetCore.Mvc;

namespace NorthWind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("ok");
        }
    }
}