using System.ComponentModel.DataAnnotations;

namespace DropDown4rmViewbag.Models
{
    public class AllClass
    {
        [Key]
        public int Id { get; set; }
        public string ClName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
