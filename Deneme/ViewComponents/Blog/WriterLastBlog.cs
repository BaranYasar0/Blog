using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.ViewComponents.Blog
{
	public class WriterLastBlog:ViewComponent
	{

		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetBlogListByWriter(5);
			return View(values);
		}
	}
}
