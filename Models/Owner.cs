using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MillionAndUp.Models
{
    [Table("Owner", Schema = "dbo")]
    public class Owner
    {
        [Key]
        public Guid IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Photo { get; set; }
        public DateTime Birthday { get; set; }

        public List<Property>? Properties { get; set; }
    }
}
