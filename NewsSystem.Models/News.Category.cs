using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    [Table("Categories", Schema = "News")]
    public class NewsCategory
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        [MaxLength(60)]
        public string Name { get; set; }
        [Column("CretorId")]
        public int UserId { get; set; }
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime EntryDate { get; set; }
        [Display(Name = "تاریخ آخرین تغییر")]
        [Required]
        public DateTime LastModified { get; set; }
        //Relations - Navigation Properties
        public virtual ICollection<Article> Articles { get; set; }
        public virtual MainUser User { get; set; }

    }
}
