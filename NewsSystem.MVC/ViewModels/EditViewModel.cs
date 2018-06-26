using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsSystem.MVC.ViewModels
{
    public class EditViewModel
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        [Display(Name = "نام فایل")]
        public string Title { get; set; }
        [Display(Name = "مسیر فایل")]
        public string FilePath { get; set; }
        [Display(Name = "نام فولدر")]
        public int MediaLibraryId { get; set; }
    }
}