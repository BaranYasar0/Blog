using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        public IActionResult InBox()
        {
            return View();
        }
    }
}
