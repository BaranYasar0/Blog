using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
    public class BlogController1 : Controller
    {
        
        BlogManager blogManager= new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values=blogManager.GetBlogListWithCategory();
            return View(values);
        }
    public IActionResult BlogReadAll(int id)
        {
            var result=blogManager.GetListByID(id);
            return View(result);
        }
    }
}
