using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Deneme.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var result = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (result != null)
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var userIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }
        
    }
}

//[AllowAnonymous]
//[HttpPost]
//      public IActionResult Index(Writer p)
//      {
//          Context c=new Context();
//	var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//	if (dataValue != null)
//	{
//		HttpContext.Session.SetString("username", p.WriterMail);
//		return RedirectToAction("Index", "Writer");
//	}
//	else
//	{
//		return View();
//	}
//      }