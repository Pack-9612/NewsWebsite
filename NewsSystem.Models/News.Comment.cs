using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    [Table("Comments", Schema = "News")]
    public class Comment
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public bool IsAnonymous { get; set; }//To check if the sender is a member of website or not
                                             //if not a member then "IsAnonymous = True".
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime EntryDate { get; set; }
        [Display(Name = "تاریخ آخرین تغییر")]
        [Required]
        public DateTime LastModified { get; set; }
        public int? AnonumousUserId { get; set; }//Because it is a 0..1 Relationship Between AnonymousUsers and Comments
        [Display(Name = "نام فرستنده")]
        public string AnonymousUserName { get; set; }//TODO: Check if this works
        //Relations - Navigation Properties
        public virtual MainUser User { get; set; }
        public virtual Article Article { get; set; }
        public virtual AnonymousUser AnonymousUser { get; set; }

    }
}
