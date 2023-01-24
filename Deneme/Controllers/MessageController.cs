using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult InBox()
        {
            int id = 4;
            var result = mm.GetInboxListByWriter(id);
            return View(result);
        }

        public IActionResult MessageDetails()
        {
            var result=mm.GetById(4);
            return View(result);
        }

    }
}
