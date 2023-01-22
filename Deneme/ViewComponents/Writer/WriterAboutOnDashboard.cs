using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var result = vm.GetWriterByID(4);
            return View(result);
        }
    }
}
