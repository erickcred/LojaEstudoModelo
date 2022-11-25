using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Administrativo.Controllers
{
    [Area("Administrativo")]
    [Controller]
    [Route("/adm/")]
    public class AdmHomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return View("Index");
        }
    }
}