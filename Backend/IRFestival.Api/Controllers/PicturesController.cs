using Microsoft.AspNetCore.Mvc;

namespace IRFestival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [HttpGet]
        public string[] GetAllPictureUrls()
        {
            return Array.Empty<string>();
        }

        [HttpPost]
        public void PostPicture(IFormFile file)
        {
        }
    }
}
