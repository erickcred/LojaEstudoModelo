using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Home.Controllers
{
    [Area("Cliente")]
    [Controller]
    [Route("/cliente/")]
    public class ClienteController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return View("Index");
        }
    }
}