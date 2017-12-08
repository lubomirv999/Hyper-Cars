namespace HyperCars.Services.Parts.Models
{
    using HyperCars.Data.Models.Enums;

    public class PartAllListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Condition Condition { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }
    }
}