using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
	public class WriterController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

	}
}
