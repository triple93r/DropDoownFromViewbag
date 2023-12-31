using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DropDown4rmViewbag.Models
{
    public class StudentClass
    {
        [Key]
        public int Id { get; set; }
        public int StudId { get; set; }
        public int ClassId { get; set; }

        [NotMapped]
        public string ClassName { get; set; }
    }
}
