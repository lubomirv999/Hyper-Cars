namespace HyperCars.Services.Cars
{
    using HyperCars.Data.Models.Enums;
    using Services.Cars.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<IEnumerable<CarAllListingServiceModel>> AllAsync();

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
    }
}