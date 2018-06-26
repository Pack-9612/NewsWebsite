using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsSystem.MVC.ViewModels
{
    public class AddViewModel
    {

        [Display(Name = "نام فایل")]
        public string Title { get; set; }
        [Display(Name = "مسیر فایل")]
        public HttpPostedFileBase FilePath { get; set; }
        [Display(Name = "نام فولدر")]
        public int MediaLibraryId { get; set; }
    }
}