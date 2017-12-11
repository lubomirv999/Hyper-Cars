namespace HyperCars.Web.Areas.Cars.Models
{
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddCarFormModel
    {
        [Required]
        [MinLength(CarModelMinLength)]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        [Range(CarMinPrice, CarMaxPrice)]
        public decimal Price { get; set; }

        [Display(Name = "Type")]
        public BodyType BodyType { get; set; }

        [Display(Name = "Transmission")]
        public TypeOfTransmission TypeOfTransmission { get; set; }

        [Display(Name = "Travelled Distance")]
        [Range(CarMinTravelledDistance, CarMaxTravelledDistance)]
        public double TravelledDistance { get; set; }

        [Display(Name = "Production year")]
        public int ProductionYear { get; set; }

        [Display(Name = "Horse power")]
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
    }
}