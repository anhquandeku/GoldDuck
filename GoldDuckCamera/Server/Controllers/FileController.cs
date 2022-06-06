using Microsoft.AspNetCore.Mvc;

namespace GoldDuckCamera.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController: ControllerBase
    {
        private readonly IWebHostEnvironment env;   
        public FileController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Please Upload File");
            string fileName = image.FileName;
            string extension = Path.GetExtension(fileName);
            string[] allow = { ".jpg", ".png", ".jpeg" };
            if (!allow.Contains(extension.ToLower())) 
                return BadRequest("Invalid Image, try again!");
            string fileNameNew = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(env.ContentRootPath, "../Client/wwwroot", "img-sanpham",fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);
            }
            return Ok($"image/{fileNameNew}");
        }
    }
}
