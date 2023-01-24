using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Deneme.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace Deneme.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
		[Authorize]
		public IActionResult Index()
		{
			var userMail = User.Identity.Name;
			Context c = new Context();
			var result = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault() ;
			ViewBag.v1 = result;
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public IActionResult Test()
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
		public IActionResult WriterEditProfile()
		{
            var userMail = User.Identity.Name;
            Context c = new Context();
            var temp = c.Writers.FirstOrDefault(x => x.WriterMail == userMail);
            var writerValues = wm.GetById(temp.WriterID);
			return View(writerValues);
		}

        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
			WriterValidator wv = new WriterValidator();
			ValidationResult results = wv.Validate(p);
			if (results.IsValid)
			{
				p.WriterImage="/writer/assets/images/faces/face3.jpg";

                wm.TUpdate(p);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
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
