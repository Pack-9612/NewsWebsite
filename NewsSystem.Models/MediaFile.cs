using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewsSystem.Models
{
    [Table("Media", Schema = "Media")]
    public class MediaFile
    {
        [Column("MediaId")]
        public int Id { get; set; }
        [Display(Name = "نام فایل")]
        public string Title { get; set; }
        [Display(Name = "انتخاب فایل")]
        public string FilePath { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime LastModified { get; set; }
        //Relations - Navigation Properties
        public virtual MainUser User { get; set; }
        public int MediaLibraryId { get; set; }
        public virtual ICollection<MediaLibrary> Library { get; set; }
        public virtual SocialNetwork SocialNetwork { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
