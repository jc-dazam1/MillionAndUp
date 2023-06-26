using System.ComponentModel.DataAnnotations;

namespace MillionAndUp.Models
{
    public class Owner
    {
        [Key]
        public long IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
