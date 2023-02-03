using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager=new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var result=commentManager.GetCommentsWithBlog();
            return View(result);
        }
    }
}
