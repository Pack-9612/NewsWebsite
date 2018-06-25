using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsSystem.Models
{
    [Table("AnonymousUsers", Schema = "User")]
    public class AnonymousUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفاً نام خود را وارد نمایید.")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime EntryDate { get; set; }
        [Display(Name = "تاریخ آخرین تغییر")]
        [Required]
        public DateTime LastModified { get; set; }
        //Relations - Navigation Properties
        public virtual ICollection<Comment> Comments { get; set; }
    }
}