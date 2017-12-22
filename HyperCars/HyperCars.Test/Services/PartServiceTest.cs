namespace HyperCars.Test.Services
{
    using HyperCars.Data;
    using HyperCars.Data.Models;
    using HyperCars.Services.Parts.Implementations;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Xunit;

    public class PartServiceTest
    {
        public PartServiceTest()
        {
        }

        [Fact]
        public async Task CreatePartAsync()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var partService = new PartService(db);

            await db.SaveChangesAsync();

            //Act
            var result = partService.Add("test", 150, Data.Models.Enums.Condition.New, "http://cdn.bmwblog.com/wp-content/uploads/2016/10/zmerc-004.jpg", "1");

            //Assert
            result.Equals(true);
        }

        [Fact]
        public async Task TotalParts()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var partService = new PartService(db);

            await db.SaveChangesAsync();

            //Act
            var result = partService.Total();

            //Assert
            result.Equals(db.Parts.CountAsync());
        }

        [Fact]
        public async Task CheckIfPartExists()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var partService = new PartService(db);

            var part = new Part
            {
                Id = 1,
                Name = "Test1"
            };

            db.AddRange(part);

            await db.SaveChangesAsync();

            //Act
            var result = partService.Exists(1);

            //Assert
            result.Equals(true);
        }

        [Fact]
        public async Task FindCarById()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var partService = new PartService(db);

            var part = new Part
            {
                Id = 2,
                Name = "Test2"
            };

            db.AddRange(part);

            await db.SaveChangesAsync();

            //Act
            var result = partService.FindById(2);

            //Assert
            result.Name.Equals("Test2");
        }

        [Fact]
        public async Task DeletePart()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var part = new Part
            {
                Id = 3,
                Name = "Test3"
            };

            var partService = new PartService(db);

            var totalCars = db.Parts.CountAsync();

            await db.SaveChangesAsync();

            //Act
            var result = partService.DeletePart(3);

            //Assert
            result.Equals(true);
        }
    }
}