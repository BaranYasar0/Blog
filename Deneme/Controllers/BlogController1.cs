using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
    [AllowAnonymous]
    public class BlogController1 : Controller
    {

        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            ViewBag.title = "Deneme";
            var result = blogManager.GetListByID(id);
            return View(result);
        }

        public IActionResult BlogListByWriter()
        {
            var values = blogManager.GetBlogListByWriter(4);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            return View();
        }
    }

}
