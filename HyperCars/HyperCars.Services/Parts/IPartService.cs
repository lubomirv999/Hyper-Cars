namespace HyperCars.Services.Parts
{
    using Data.Models.Enums;
    using HyperCars.Services.Parts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartService
    {
        Task<IEnumerable<PartAllListingServiceModel>> AllAsync();

        bool Add(
            string name,
            decimal price,
            Condition condition,
            string imageUrl,
            string userId);
    }
}