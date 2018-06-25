using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Models
{
    [Table("MediaLibrary", Schema = "Media")]
    public class MediaLibrary
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string LibraryName { get; set; }
        //Relations - Navigation Properties
        public virtual ICollection<MediaFile> MediaFiles { get; set; }

    }
}
