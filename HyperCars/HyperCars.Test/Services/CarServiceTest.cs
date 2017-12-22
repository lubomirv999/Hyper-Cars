namespace HyperCars.Test.Services
{
    using HyperCars.Data;
    using HyperCars.Data.Models;
    using HyperCars.Data.Models.Enums;
    using HyperCars.Services.Cars.Implementations;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Xunit;

    public class CarServiceTest
    {
        public CarServiceTest()
        {
            StartUpTest.Initialize();
        }

        [Fact]
        public async Task CreateCarAsync()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var carService = new CarService(db);

            await db.SaveChangesAsync();

            //Act
            var result = carService.Add("test",
                1000,
                BodyType.Sedan,
                TypeOfTransmission.Manual,
                150000,
                1999,
                100,
                "Black",
                "https://chastite.com/data/cars/opel/opel-insignia.jpg",
                "1");

            //Assert
            result.Equals(true);
        }

        [Fact]
        public async Task TotalCars()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var carService = new CarService(db);

            await db.SaveChangesAsync();

            //Act
            var result = carService.Total();

            //Assert
            result.Equals(db.Cars.CountAsync());
        }

        [Fact]
        public async Task CheckIfCarExists()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var carService = new CarService(db);

            var car = new Car
            {
                Id = 2,
                Model = "Test2"
            };

            db.AddRange(car);

            await db.SaveChangesAsync();

            //Act
            var result = carService.Exists(1);

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

            var carService = new CarService(db);

            var car = new Car
            {
                Id = 1,
                Model = "Test"
            };

            db.AddRange(car);

            await db.SaveChangesAsync();

            //Act
            var result = carService.FindById(1);

            //Assert
            result.Model.Equals("Test");
        }

        [Fact]
        public async Task DeleteCar()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<HyperCarsDbContext>()
                .UseInMemoryDatabase("HyperCarsDb")
                .Options;

            var db = new HyperCarsDbContext(dbOptions);

            var car = new Car
            {
                Id = 4,
                Model = "Test4"
            };

            var carService = new CarService(db);

            var totalCars = db.Cars.CountAsync();

            await db.SaveChangesAsync();

            //Act
            var result = carService.DeleteCar(4);

            //Assert
            result.Equals(true);
        }
    }
}