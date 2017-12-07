﻿namespace HyperCars.Services.Admin.Models
{
    using Core.Mapping;
    using Data.Models;

    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}