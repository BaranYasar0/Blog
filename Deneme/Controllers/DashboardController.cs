using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            var userMail = User.Identity.Name;
            var writerMail = c.Users.Where(x => x.UserName == userMail).Select(y => y.Email).FirstOrDefault();
            var writerId=c.Writers.Where(x=>x.WriterMail==writerMail).Select(y=>y.WriterID).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerId).Count().ToString();
            ViewBag.v3=c.Categories.Count().ToString();
            return View();
        }
    }
}
