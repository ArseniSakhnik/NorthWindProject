using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Core.Entities.Services.Files;
using NorthWindProject.Application.Common.Access;

namespace NorthWind.API.Controllers
{
    public class ImageController : ApiController
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ImageController(AppDbContext context, IWebHostEnvironment appEnvironment,
            IWebHostEnvironment environment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(CancellationToken cancellationToken)
        {
            var file = Request.Form.Files.SingleOrDefault();
            if (file != null)
            {
                var path = "/serviceimage/" + file.FileName;

                await using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream, cancellationToken);
                }

                var fileModel = new ServiceFile {Name = file.FileName, Path = path};
                _context.ServiceFiles.Add(fileModel);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Ok();
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetImage()
        {
            var path = Path.Combine(_environment.WebRootPath, "serviceimage", "6LAkuTNr_0Y.png");
            var imageFileStream = System.IO.File.OpenRead(path);
            return File(imageFileStream, "image/jpeg");
        }
    }
}