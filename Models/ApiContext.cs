using Microsoft.EntityFrameworkCore;
namespace MillionAndUp.Models
{
    public class ApiContext :DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertiesImages { get; set; }
        public DbSet<PropertyTrace> PropertiesTraces { get; set; }
        //Constructor
        public ApiContext()
        {

        }


        /// <summary>
        /// Create Models in Database with entity framework
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(o => o.Owner)
                .WithMany(p => p.Properties)
                .HasForeignKey(o => o.IdOwner);

            modelBuilder.Entity<PropertyTrace>()
                .HasOne(o => o.Property)
                .WithMany(p => p.PropertyTraces)
                .HasForeignKey(o => o.IdProperty);

            modelBuilder.Entity<PropertyImage>()
             .HasOne(o => o.Property)
             .WithMany(p => p.PropertyImages)
             .HasForeignKey(o => o.IdProperty);


            //Seed data in Database
            new DbInitializer(modelBuilder).Seed();
        }

    }

}
