﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
    Context c=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
    }
}
