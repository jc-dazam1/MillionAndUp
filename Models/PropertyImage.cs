using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models
{
    public class PropertyImage
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("IdProperty")]
        public Property IdProperty { get; set; }
        public string file { get; set; }
        public Boolean Enabled { get; set; }
    }
}
