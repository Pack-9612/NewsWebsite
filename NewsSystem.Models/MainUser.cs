using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    [Table("Users" , Schema = "User")]
    public class MainUser
    {
        public int Id { get; set; }
        [MaxLength(100) , Required(ErrorMessage = "username is required")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [MaxLength(50)]
        [Display(Name = "نام")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required") , EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required , StringLength(100, MinimumLength = 6) , DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "تلفن")]
        public int phone { get; set; }
        [Display(Name = "جنسیت")]
        public string Gender { get; set; }
        public string ProfilePicPath { get; set; }
        public bool UserEnable { get; set; }
        [Display(Name = "آخرین ورود")]
        public DateTime LastLogOn { get; set; }
        //Relations - Navigation Properties
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<MediaFile> Media { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<EventCategory> EventCategories { get; set; }
        public virtual ICollection<EventTag> EventTags { get; set; }
        public virtual ICollection<NewsCategory> NewsCategories { get; set; }
        public virtual ICollection<NewsTag> NewsTags { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

    }
}
