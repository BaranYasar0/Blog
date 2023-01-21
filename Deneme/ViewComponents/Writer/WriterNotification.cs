using Microsoft.AspNetCore.Mvc;

namespace Deneme.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
    public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
