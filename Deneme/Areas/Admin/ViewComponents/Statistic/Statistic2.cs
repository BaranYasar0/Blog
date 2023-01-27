using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2:ViewComponent
    {
    Context c=new Context();
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
