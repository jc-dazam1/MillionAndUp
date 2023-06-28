using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models
{
    [Table("Property", Schema = "dbo")]
    public class Property
    {
        [Key]
        public Guid IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double? Price { get; set; }
        public string? CodeInternal { get; set; }
        public string? Year { get; set; }
        // One-to-many relation with Owner
        public Guid? IdOwner { get; set; }
        public Owner? Owner { get; set; }
        // One-to-many relation with PropertyTrace
        public List<PropertyTrace>? PropertyTraces { get; set; }
        public List<PropertyImage>? PropertyImages { get; set; }

    }
}
