namespace HyperCars.Services.Parts
{
    using HyperCars.Services.Parts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartService
    {
        Task<IEnumerable<PartAllListingServiceModel>> AllAsync();
    }
}