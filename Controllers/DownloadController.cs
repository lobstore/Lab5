using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class DownloadController:Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DownloadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download(string fileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public IActionResult Preview(string fileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }
    }
}
