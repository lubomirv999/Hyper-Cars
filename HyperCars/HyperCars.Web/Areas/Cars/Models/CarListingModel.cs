namespace HyperCars.Web.Areas.Cars.Models
{
    using HyperCars.Services.Cars.Models;
    using System.Collections.Generic;

    public class CarListingModel
    {
        public IEnumerable<CarAllListingServiceModel> Cars { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1
            ? 1
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages
            ? this.TotalPages
            : this.CurrentPage + 1;
    }
}