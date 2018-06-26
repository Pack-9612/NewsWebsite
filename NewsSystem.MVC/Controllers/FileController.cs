using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsSystem.MVC.Models;
using NewsSystem.Models;
using NewsSystem.MVC.ViewModels;
using System.IO;

namespace NewsSystem.MVC.Controllers
{
    public class FileController : Controller
    {
        public ActionResult Show()
        {
            Context ctx = new Context();
            return View(ctx.Files.ToList());
        }

        public ActionResult Add()
        {
            Context ctx = new Context();
            ViewBag.MediaLibraryId = new SelectList(ctx.Files, "Id", "LibraryName");
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addModel)
        {
            var extension = "";
            if (addModel.FilePath != null)
            {
                extension = Path.GetExtension(addModel.FilePath.FileName).ToLower();
                if (addModel.FilePath.ContentLength / 1024 >= 500)
                {
                    ModelState.AddModelError("FilePath", "سایز فایل باید حداکثر 300 کیلوبایت باشد.");
                }
                if (!(extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif"))
                {
                    ModelState.AddModelError("FilePath", "فرمت فایل مورد قبول نیست");
                }
            }

            Context ctx = new Context();
            if (ModelState.IsValid)
            {
                var fileName = $"{DateTime.Now.ToString("yymmssfff")}{extension}";
                var fullPath = Path.Combine(Server.MapPath("~/Image/Thumbnail"), fileName);
                addModel.FilePath.SaveAs(fullPath);
                var ImagesClientPath = $"/Images/thumbnails/{fileName}";

                MediaFile fm = new MediaFile()
                {
                    Title = addModel.Title,
                    MediaLibraryId = addModel.MediaLibraryId,
                    FilePath = ImagesClientPath
                };

                ctx.Files.Add(fm);
                ctx.SaveChanges();

                TempData["Message"] = "ثبت با موفقیت انجام شد.";
                return RedirectToAction("Show", "File");
                //return View();
            }

            return View(addModel);
        }

    }
}