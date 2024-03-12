using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Services.RentAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? SurName { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Já existe o CNPJ cadastrado em nossa base de dados.")]
        public string DocumentId { get; set; }
        public DateTime DateBirth { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Carteira de Motorista já cadastrada em nossa base de dados.")]
        public string? DriverLicenseId { get; set; }
        public string? DriverLicenseClass { get; set; }
        public string? DriverLicenseImageUrl { get; set; }
        public string? DriverLicenseImageLocalPath { get; set; }
    }
}
