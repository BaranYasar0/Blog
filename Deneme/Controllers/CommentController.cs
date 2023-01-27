using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
			p.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.CommentStatus = true;
			p.BlogId = 19;
			cm.CommentAdd(p);
			
			Response.Redirect("/BlogController1/Index");
			return PartialView();
        }
        
	}
}
