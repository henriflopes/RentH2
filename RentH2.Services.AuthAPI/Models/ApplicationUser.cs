using Microsoft.AspNetCore.Identity;

namespace RentH2.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? SurName { get; set; }
    }
}
