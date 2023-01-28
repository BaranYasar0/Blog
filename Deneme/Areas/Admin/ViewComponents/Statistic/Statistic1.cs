using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Deneme.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {

        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();

   
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetAll().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string apiKey = "6e61fe359e1e94154ff0731f35227082";
            string connectionLink = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid=" + apiKey;
XDocument document =XDocument.Load(connectionLink);
            var temp = float.Parse(document.Descendants("temperature").ElementAt(0).Attribute("value").Value);
            ViewBag.v4 =temp;
            return View();
        }
    }
}
