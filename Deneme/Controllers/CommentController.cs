using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.Extensions;
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
			ViewBag.v1 = "dfsdfsdfs";
            return PartialView();
		}
        [HttpPost]
        public IActionResult PartialAddComment(Comment p)
        {
            Context c = new Context();
            ViewBag.v1 = "dfsdfsdfs";
            var temp = Url.ActionContext.HttpContext.Request.Scheme;
			var result=temp.Substring(temp.Length - 2);
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogId =Int16.Parse(result);
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
