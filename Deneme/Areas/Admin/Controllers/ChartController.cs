using Deneme.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]

    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categorycount = 10, categoryname = "Teknoloji" });
            list.Add(new CategoryClass { categorycount = 14, categoryname = "Yazılım" });
            list.Add(new CategoryClass { categorycount = 5, categoryname = "Spor" });
            return Json(new { jsonlist = list });
        }
        
    }
}
