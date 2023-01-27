using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Deneme.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{

		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IViewComponentResult Invoke(int id,int page=1)
		{
			var values = cm.GetAll(id);
			return View(values);
		}
	}
}
