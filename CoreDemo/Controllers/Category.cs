using Microsoft.AspNetCore.Mvc;
using BusinessLayer

namespace CoreDemo.Controllers
{
    public class Category : Controller
    {
        CategoryManager
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
