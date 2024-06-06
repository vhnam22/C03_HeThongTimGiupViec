using Microsoft.AspNetCore.Mvc;

namespace C03_HeThongTimGiupViec.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok(new { Path = "/Images/" + fileName }); // Trả về đường dẫn của ảnh đã lưu
            }
            else
            {
                return BadRequest("No file uploaded");
            }
        }
    }
}
