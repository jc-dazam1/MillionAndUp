using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MillionAndUp.Controllers;
using MillionAndUp.Models;
using Moq;
using NUnit.Framework;
using System;

namespace MillionAndUp.Unit_Tests
{
    [TestFixture]
    public class TestAPI
    {

        private PropertiesController _controller;
        private Mock<ApiContext> _apiContextMock;

        [SetUp]
        public void SetUp()
        {
            _apiContextMock = new Mock<ApiContext>();
            _controller = new PropertiesController(_apiContextMock.Object);
        }

        [Test]
        public async Task TestGetAllPropertiesAsync()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "APIMUP")
                .Options;

            using (var context = new ApiContext(options))
            {
                // Agregar datos de prueba al contexto
                var controller = new PropertiesController(context);

                // Act
                var result = await controller.GetProperties();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult<IEnumerable<Property>>>(result);

              
            }
        }

        [Test]
        public async Task GetProperty_ReturnsProperty()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "APIMUP")
                .Options;

            // Crea una instancia del ApiContext utilizando el DbContextOptions personalizado
            using (var context = new ApiContext(options))
            {
                // Agrega una propiedad ficticia al contexto para la prueba
                var propertyId = Guid.NewGuid();
                var property = new Property { IdProperty = propertyId, Name = "Test Property" };
                context.Properties.Add(property);
                context.SaveChanges();

                // Crea una instancia del controlador bajo prueba y pasa el ApiContext específico
                var controller = new PropertiesController(context);

                // Act
                var result = await controller.GetProperty(propertyId);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult<Property>>(result);


            }

        }

        [Test]
        public async Task PostPropertyImage()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "APIMUP")
                .Options;
            var dbContext = new ApiContext(dbContextOptions); // Crea una instancia del ApiContext con opciones de base de datos en memoria

            var controller = new PropertyImagesController(dbContext);

            var propertyId = Guid.NewGuid();
            var property = new Property { IdProperty = propertyId, Name = "Test Property" };

            var propertyImage = new PropertyImage
            {

                IdProperty = property.IdProperty,
                file = "",
                Enabled = true

            };

            // Act
            var result = await controller.PostPropertyImage(propertyImage);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActionResult<PropertyImage>>(result);
            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);

        }

        [Test]
        public async Task UpdateProperty_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid(); // Id de propiedad ficticia
            var propertyUpdateModel = new Property { IdProperty= id, Name= "Test Update Property", CodeInternal="12346"};

            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "APIMUP")
                .Options;

            using (var context = new ApiContext(options))
            {
                // Agregar una propiedad existente al contexto para actualizarla
                var existingProperty = new Property { IdProperty = id, Name = "Test Existing Property", CodeInternal = "6789" };
                context.Properties.Add(existingProperty);
                context.SaveChanges();
            }

            var controller = new PropertiesController(new ApiContext(options));

            // Act
            var result = controller.UpdateProperty(id, propertyUpdateModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task GetPropertyFilter()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "APIMUP")
                .Options;

            // Crear y poblar una instancia de ApiContext con datos de prueba
            var id = Guid.NewGuid(); // Id de propiedad ficticia
            using (var context = new ApiContext(options))
            {
                var property = new Property { IdProperty = id, Name = "Test Existing Property", CodeInternal = "6789", Year="1989"};
                context.Properties.Add(property);
                context.SaveChanges();
            }

            using (var context = new ApiContext(options))
            {
                var controller = new PropertiesController(context);

                // Act
                var result = await controller.GetPropertyFilter(new Property
                {
                    Year = "1989"
                });

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult<Property>>(result);

 
            }
        }
    }
}
