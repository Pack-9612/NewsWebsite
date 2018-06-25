using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    [Table("Articles", Schema = "News")]
    public class Article
    {
        public int Id { get; set; }
        [Display(Name = "تیتر")]
        [MaxLength(120)]
        [Required]
        public string MainTitle { get; set; }
        [Display(Name = "تصویر اصلی")]
        [MaxLength(500)]
        public string MainImgUrl { get; set; }
        [Display(Name = "تصویر بند انگشتی")]
        [MaxLength(500)]
        public string ThumbnailImgUrl { get; set; }
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime EntryDate { get; set; }
        [Display(Name = "تاریخ آخرین تغییر")]
        [Required]
        public DateTime LastModified { get; set; }
        [Display(Name = "تاریخ تقویم")]
        public DateTime? CalendarDate { get; set; }
        public string JSONContent { get; set; }
        [Display(Name = "دسته بندی")]
        public string CategoryName { get; set; }
        [Display(Name = "مجموع نظرها")]
        [NotMapped]
        public int SumComments { get; set; } = 0;
        [Display(Name = "مجموع به اشتراک گذاری")]
        public int SumShares { get; set; } = 0;
        [Display(Name = "مجموع بازدیدها")]
        [NotMapped]
        public int SumViews { get; set; } = 0;
        //Relations - Navigation Properties
        public virtual MainUser User { get; set; }
        public virtual NewsCategory Category { get; set; }
        public virtual ICollection<MediaFile> Media { get; set; }
        public virtual ICollection<NewsTag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
