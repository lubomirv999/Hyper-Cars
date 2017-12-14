namespace HyperCars.Services.Cars
{
    using HyperCars.Data.Models.Enums;
    using Services.Cars.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<IEnumerable<CarAllListingServiceModel>> AllAsync(int page = 1, int pageSize = 6);

        bool Add(
            string model,
            decimal price,
            BodyType bodyType,
            TypeOfTransmission typeOfTransmission,
            double TravelledDistance,
            int productionYear,
            int horsePower,
            string color,
            string imageUrl,
            string userId);

        CarAllListingServiceModel Buy(int id);

        void Edit(
            int id,
            string model,
            decimal price,
            BodyType bodyType,
            TypeOfTransmission typeOfTransmission,
            double TravelledDistance,
            int productionYear,
            int horsePower,
            string color,
            string imageUrl);

        CarAllListingServiceModel FindById(int id);

        bool Exists(int id);

        bool DeleteCar(int id);

        int Total();
    }
}