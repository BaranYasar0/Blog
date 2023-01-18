using Deneme.Models;
using Microsoft.AspNetCore.Mvc;



namespace Deneme.ViewComponents
{
	public class CommentList:ViewComponent
	{
	public IViewComponentResult Invoke()
		{
			var comment = new List<UserComment>
			{
			new UserComment
			{
				ID=1,
				Name="S2ciBaro"
			},
			new UserComment
			{
				ID=2,
				Name="KaTiLBaro"
			},
            new UserComment
            {
                ID=3,
                Name="zort"
            }
            };
			return View(comment);
		}
	}
}
