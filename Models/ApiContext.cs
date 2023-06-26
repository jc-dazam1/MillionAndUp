using Microsoft.EntityFrameworkCore;
namespace MillionAndUp.Models
{
    public class ApiContext :DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertiesImage { get; set; }
        public DbSet<PropertyTrace> PropertiesTrace { get; set; }

    }

}
