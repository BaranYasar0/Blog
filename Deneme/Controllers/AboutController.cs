using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
	public class AboutController : Controller
	{

		AboutManager am = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var values = am.GetAll();
            return View(values);
		}
public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
