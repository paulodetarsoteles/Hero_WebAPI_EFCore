using Microsoft.AspNetCore.Mvc;

namespace Hero_WebAPI_EFCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return Ok("API Running...");
        }
    }
}
