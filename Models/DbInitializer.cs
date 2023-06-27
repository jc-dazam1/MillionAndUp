using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MillionAndUp.Models
{
    internal class DbInitializer
    {
        private ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }


        public void Seed()
        {
            this.modelBuilder.Entity<Owner>(o =>
            {
                o.HasData(new Owner
                {
                    IdOwner = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    Name = "J.K. Rowling",
                    Address = "Ever Green 123",
                    Photo = null,
                    Birthday = new DateTime(1965, 07, 31),
                });
                o.HasData(new Owner
                {
                    IdOwner = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                    Name = "Walter Isaacson",
                    Address = "Simple Red 456",
                    Photo = null,
                    Birthday = new DateTime(1952, 05, 20),
                });
                o.HasData(new Owner
                {
                    IdOwner = new Guid("e6c91df6-ce2e-4d27-8737-ebf0d6732f8c"),
                    Name = "Laura Simpson",
                    Address = "Axel 2323",
                    Photo = null,
                    Birthday = new DateTime(1970, 10, 21),
                });

            });
        }
    }
}