using Deneme.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            List<WriterClass> writers = new List<WriterClass> {
        new WriterClass{Id=1,Name="brn"},
        new WriterClass{Id=2,Name="brn2"},
        new WriterClass{Id=3,Name="brn3"} };

            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
    }
}
