﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
	public class ContactController : Controller
	{

		ContactManager cm = new ContactManager(new EfContactRepository());
		
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Index(Contact p)
        {
			p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			p.ContactStatus = true;
			cm.ContactAdd(p);
			return RedirectToAction("Index","BlogController1");
        }
    }
}
