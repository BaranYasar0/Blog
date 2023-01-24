using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            Context c = new Context();
            var temp = c.Writers.FirstOrDefault(x => x.WriterMail == userMail);
            var result = vm.GetWriterByID(temp.WriterID);
            return View(result);
        }
    }
}
