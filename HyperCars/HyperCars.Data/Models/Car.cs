namespace HyperCars.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CarModelMinLength)]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        [Range(CarMinPrice, CarMaxPrice)]
        public decimal Price { get; set; }

        public BodyType BodyType { get; set; }

        public TypeOfTransmission TypeOfTransmission { get; set; }

        [Range(CarMinTravelledDistance, CarMaxTravelledDistance)]
        public double TravelledDistance { get; set; }

        public int YearOfProduction { get; set; }

        [Range(CarMinHorsePower, CarMaxHorsePower)]
        public int HorsePower { get; set; }

        [Required]
        [MinLength(CarColorMinLength)]
        [MaxLength(CarColorMaxLength)]
        public string Color { get; set; }

        [Required]
        [MinLength(CarImageUrlMinLength)]
        [MaxLength(CarImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}