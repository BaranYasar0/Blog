using Microsoft.AspNetCore.Mvc;

namespace Deneme.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
    public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
