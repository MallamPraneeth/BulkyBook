using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category1
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 to 100 only!")]
        public int DisplayOrder { get; set; }
        [DisplayName("Created DateTime")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
