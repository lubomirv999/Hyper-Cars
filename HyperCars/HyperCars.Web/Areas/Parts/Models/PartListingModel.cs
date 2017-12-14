namespace HyperCars.Web.Areas.Parts.Models
{
    using HyperCars.Services.Parts.Models;
    using System.Collections.Generic;

    public class PartListingModel
    {
        public IEnumerable<PartAllListingServiceModel> Parts { get; set; }

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