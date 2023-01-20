using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
	public class CommentController : Controller
	{

		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogId = 19;
			cm.CommentAdd(p);
			Response.Redirect("/BlogController1/Index");
			return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
		{
			ViewBag.str = "Deneme";
			var result=cm.GetAll(id);
			return PartialView(result );
		}
	}
}
