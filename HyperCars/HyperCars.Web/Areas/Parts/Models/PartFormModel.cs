namespace HyperCars.Web.Areas.Parts.Models
{
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    using static HyperCars.Data.DataConstants;

    public class PartFormModel
    {
        [Required]
        [MinLength(PartNameMinLength)]
        [MaxLength(PartNameMaxLength)]
        public string Name { get; set; }

        [Range(PartMinPrice, PartMaxPrice)]
        public decimal Price { get; set; }

        public Condition Condition { get; set; }

        [Required]
        [MinLength(PartImageUrlMinLength)]
        [MaxLength(PartImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }
    }
}