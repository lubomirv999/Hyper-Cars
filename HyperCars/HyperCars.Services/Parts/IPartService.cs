namespace HyperCars.Services.Parts
{
    using Data.Models.Enums;
    using HyperCars.Services.Parts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartService
    {
        Task<IEnumerable<PartAllListingServiceModel>> AllAsync(int page = 1, int pageSize = 6);

        bool Add(
            string name,
            decimal price,
            Condition condition,
            string imageUrl,
            string userId);

        PartAllListingServiceModel Buy(int id);

        void Edit(
            int id,
            string name,
            decimal price,
            Condition condition,
            string imageUrl);

        PartAllListingServiceModel FindById(int id);

        bool Exists(int id);

        bool DeletePart(int id);

        int Total();
    }
}