using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Deneme.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace Deneme.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
		private readonly UserManager<AppUser> _userManager;
		UserManager userManager = new UserManager(new EfUserRepository());

		public WriterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		public IActionResult Index()
		{
			var userMail = User.Identity.Name;
			var result = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault() ;
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
		public PartialViewResult WriterFooterPartial() 
		{ 
			return PartialView(); 
		}

		[HttpGet]
		public async Task<IActionResult> WriterEditProfile()
		{

			//var userName = User.Identity.Name;
			//var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
			//var id = c.Users.Where(x => x.Email == userMail).Select(y => y.Id).FirstOrDefault();
			//var values = userManager.GetById(id);
			var result = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model=new UserUpdateViewModel();
            model.mail = result.Email;
            model.namesurname = result.NameSurname;
            model.imageurl = result.ImageUrl;
            model.username = result.UserName;
            return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
			var result = await _userManager.FindByNameAsync(User.Identity.Name);
			result.ImageUrl = model.imageurl;
			result.NameSurname = model.namesurname;
			result.Email = model.mail;
			result.UserName = model.username;
			result.PasswordHash = _userManager.PasswordHasher.HashPassword(result, model.password);
			var values = await _userManager.UpdateAsync(result);

			if (ModelState.IsValid)
			{
                return RedirectToAction("Index", "Dashboard");

            }
			return View();	
        }
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
			Writer w = new Writer();
			if (p.WriterImage != null)
			{
				var extension = Path.GetExtension(p.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				p.WriterImage.CopyTo(stream);
				w.WriterImage = newImageName;
			}
			w.WriterStatus = true;
			w.WriterName = p.WriterName;
			w.WriterPassword=p.WriterPassword;
			w.WriterAbout = p.WriterAbout;
			w.WriterMail = p.WriterMail;
			wm.TAdd(w);
			return RedirectToAction("Index", "Dashboard");
		}


    }

}
