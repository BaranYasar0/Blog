using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {
        [Area("Admin")]
        [Route("Admin/[Controller]/[Action]/{id?}")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
