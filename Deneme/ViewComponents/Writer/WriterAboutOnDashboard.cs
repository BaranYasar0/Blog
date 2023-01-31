using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        Context c = new Context();

        public WriterAboutOnDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            //var user1 = await _userManager.FindByNameAsync(User.Identity.Name);
            var user1 = User.Identity.Name;
            ViewBag.v9 = user1;
            
            var user = _userManager.Users.FirstOrDefault(x=>x.UserName==user1);
            var temp = c.Writers.FirstOrDefault(x => x.WriterMail == user.Email);
            var result = vm.GetWriterByID(temp.WriterID);
            return View(result);
        }
    }
}
