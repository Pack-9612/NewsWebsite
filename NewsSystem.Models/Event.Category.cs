using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    [Table("Categories", Schema = "Event")]
    public class EventCategory
    {
        public int Id { get; set; }
        [Display(Name = "تیتر")]
        [MaxLength(120)]
        [Required]
        public string MainTitle { get; set; }
        public TimeSpan BeginTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [MaxLength(240)]
        public string Address { get; set; }
        [Display(Name = "نام")]
        [MaxLength(60)]
        public string Name { get; set; }
        [Column("CreatorId")]
        public int UserId { get; set; }
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime EntryDate { get; set; }
        [Display(Name = "تاریخ آخرین تغییر")]
        [Required]
        public DateTime LastModified { get; set; }
        //Relations - Navigation Properties
        public virtual ICollection<Event> Events { get; set; }
        public virtual MainUser User { get; set; }

    }
}
