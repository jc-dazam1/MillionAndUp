using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models
{
    [Table("PropertyImage", Schema = "dbo")]
    public class PropertyImage
    {
        [Key]
        public Guid IdPropertyImage { get; set; }
        public Guid? IdProperty { get; set; }
        public Property? Property { get; set; }
        public string file { get; set; }
        public Boolean Enabled { get; set; }
    }
}
