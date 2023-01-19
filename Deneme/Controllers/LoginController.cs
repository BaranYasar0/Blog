using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
