using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using Deneme.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                var cellCount = 2;
                foreach (var item in bm.GetAll())
                {
                    worksheet.Cell(cellCount, 1).Value = item.BlogId;
                    worksheet.Cell(cellCount, 2).Value = item.BlogTitle;
                    cellCount++;
                }
                using (var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
        }

    public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
