using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Services.Files;
using Spire.Doc.Documents;

namespace NorthWind.API.Controllers
{
    public class ImageController : ApiController
    {
        private AppDbContext _context;
        private IWebHostEnvironment _appEnvironment;
        private IWebHostEnvironment _environment;

        public ImageController(AppDbContext context, IWebHostEnvironment appEnvironment, IWebHostEnvironment environment)
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

                var fileModel = new ServiceFile() {Name = file.FileName, Path = path};
                _context.ServiceFiles.Add(fileModel);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Ok();
        }

        [HttpGet("image")]
        public async Task<IActionResult> GetImage()
        {
            var path = Path.Combine(_environment.WebRootPath, "serviceimage", $"6LAkuTNr_0Y.png");
            var imageFileStream = System.IO.File.OpenRead(path);
            return File(imageFileStream, "image/jpeg");
        }
    }
}