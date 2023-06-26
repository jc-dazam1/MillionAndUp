using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models
{
    public class PropertyTrace
    {
        [Key]
        public long IdPropertyTrace { get; set; }
        public DateOnly DateSale { get; set; }
        public string Name { get; set; }
        public Double Value { get; set; }
        public Double Tax { get; set; }
        [ForeignKey("IdProperty")]
        public Property IdProperty { get; set; }
    }
}
