using Microsoft.AspNetCore.Mvc;

namespace Hero_WebAPI_EFCore.Web.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return Ok("API running");
        }
    }
}
