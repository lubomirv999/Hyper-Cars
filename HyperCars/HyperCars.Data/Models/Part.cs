namespace HyperCars.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Part
    {
        public int Id { get; set; }

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

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}