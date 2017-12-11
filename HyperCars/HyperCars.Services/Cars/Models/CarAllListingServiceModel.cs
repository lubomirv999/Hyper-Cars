namespace HyperCars.Services.Cars.Models
{
    using Data.Models.Enums;

    public class CarAllListingServiceModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public BodyType BodyType { get; set; }

        public TypeOfTransmission TypeOfTransmission { get; set; }

        public double TravelledDistance { get; set; }

        public int ProductionYear { get; set; }

        public int HorsePower { get; set; }

        public string ImageUrl { get; set; }

        public string Color { get; set; }

        public string UserId { get; set; }
    }
}