using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Models
{
    public class Category
    {
        [Key] //These are Data Annotations.
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
