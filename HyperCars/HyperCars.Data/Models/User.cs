namespace HyperCars.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();

        public List<Part> Parts { get; set; } = new List<Part>();
    }
}