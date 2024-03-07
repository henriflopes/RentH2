﻿using Microsoft.AspNetCore.Identity;

namespace RentH2.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? SurName { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateBirth { get; set; }
        public string? DriverLicenseId { get; set; }
		public string? DriverLicenseClass { get; set; }
		public string? DriverLicenseImageUrl { get; set; }
		public string? DriverLicenseImageLocalPath { get; set; }
	}
}