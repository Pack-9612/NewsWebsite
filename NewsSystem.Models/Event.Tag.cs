using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsSystem.Models
{
    public class EventTag
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
        public virtual MainUser User { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}