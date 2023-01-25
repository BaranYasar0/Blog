using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
