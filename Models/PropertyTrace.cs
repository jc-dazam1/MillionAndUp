using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models
{
    [Table("PropertyTrace", Schema = "dbo")]
    public class PropertyTrace
    {
        [Key]
        public Guid IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public Double Value { get; set; }
        public Double Tax { get; set; }
        public Guid? IdProperty { get; set; }
        public Property? Property { get; set; }
    }
}
