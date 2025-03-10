﻿using Deneme.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWriterById(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriter= JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        [HttpDelete]
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }

        [HttpPut]
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var json = JsonConvert.SerializeObject(w);
            return Json(json);
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public static List<WriterClass> writers = new List<WriterClass> {
        new WriterClass{Id=1,Name="brn"},
        new WriterClass{Id=2,Name="brn2"},
        new WriterClass{Id=3,Name="brn3"} };
    }
}
