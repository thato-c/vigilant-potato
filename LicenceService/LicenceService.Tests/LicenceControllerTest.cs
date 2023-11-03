using LicenceService.Controllers;
using LicenceService.Data;
using LicenceService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenceService.Tests
{
    public class LicenceControllerTest
    {

        [Fact]
        public async void Index_ReturnsViewWithLicences()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<LicenceContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LicencePurchase;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            // Using a real database context
            using (var context = new LicenceContext(dbContextOptions))
            {
                // Add sample data to the actual database
                context.Licences.Add(new Models.Licence { 
                    Name = "Sample Licence 1",
                    Description = "Description 1",
                    Cost = 10,
                    ValidityMonths = 1,
                });

                context.Licences.Add(new Models.Licence
                {
                    Name = "Sample Licence 2",
                    Description = "Description 2",
                    Cost = 10,
                    ValidityMonths = 6,
                });

                context.SaveChanges();
            }

            using (var context = new LicenceContext(dbContextOptions))
            {
                var controller = new LicenceController(context);

                // Act
                var result = await controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Licence>>(viewResult.Model);

                Assert.NotEmpty(model);
                Assert.Null(viewResult.ViewData["Message"]);

            }
        
        }

    }
}