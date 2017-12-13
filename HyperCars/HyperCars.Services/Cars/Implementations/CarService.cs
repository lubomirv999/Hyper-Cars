namespace HyperCars.Services.Cars.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Cars.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly HyperCarsDbContext db;

        public CarService(
            HyperCarsDbContext db,
            UserManager<User> userManager)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CarAllListingServiceModel>> AllAsync() => await this.db
                .Cars
                .ProjectTo<CarAllListingServiceModel>()
                .ToListAsync();

        public bool Add(string model, decimal price, BodyType bodyType, TypeOfTransmission typeOfTransmission, double travelledDistance, int productionYear, int horsePower, string color, string imageUrl, string userId)
        {
            if (!this.db.Users.Any(u => u.Id == userId))
            {
                return false;
            }

            var car = new Car
            {
                Model = model,
                Price = price,
                BodyType = bodyType,
                TypeOfTransmission = typeOfTransmission,
                TravelledDistance = travelledDistance,
                ProductionYear = productionYear,
                HorsePower = horsePower,
                Color = color,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.db.Cars.Add(car);
            this.db.SaveChanges();

            return true;
        }

        public CarAllListingServiceModel FindById(int id)
            => this.db
                .Cars
                .Where(c => c.Id == id)
                .ProjectTo<CarAllListingServiceModel>()
                .FirstOrDefault();

        public bool Exists(int id)
            => this.db.Cars.Any(c => c.Id == id);

        public void Edit(int id, string model, decimal price, BodyType bodyType, TypeOfTransmission typeOfTransmission, double travelledDistance, int productionYear, int horsePower, string color, string imageUrl)
        {
            if (!this.db.Cars.Any(p => p.Id == id))
            {
                return;
            }

            var car = this.db.Cars.Find(id);

            if (car == null)
            {
                return;
            }

            // Editing the car

            car.Model = model;
            car.Price = price;
            car.BodyType = bodyType;
            car.TypeOfTransmission = typeOfTransmission;
            car.TravelledDistance = travelledDistance;
            car.ProductionYear = productionYear;
            car.HorsePower = horsePower;
            car.Color = color;
            car.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public bool DeleteCar(int id)
        {
            var car = this.db.Cars.Find(id);

            if (car == null)
            {
                return false;
            }

            this.db.Cars.Remove(car);
            this.db.SaveChanges();

            return true;
        }
    }
}