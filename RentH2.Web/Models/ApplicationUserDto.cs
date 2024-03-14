using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
	public class ApplicationUserDto
    {
        public string Id { get; set; }
		[Display(Name = "Nome")]
		public string Name { get; set; }
        public string? SurName { get; set; }
		[Display(Name = "Telefone")]
		public string PhoneNumber { get; set; }
		[Display(Name = "E-mail")]
		public string Email { get; set; }
		[Display(Name = "CNPJ")]
		public string DocumentId { get; set; }
		[Display(Name = "Data de Nascimento")]
		public DateTime DateBirth { get; set; }
		[Display(Name = "Numero Carteira de Motorista")]
		public string? DriverLicenseId { get; set; }
		[Display(Name = "Classe")]
		public string? DriverLicenseClass { get; set; }
        public string? DriverLicenseImageUrl { get; set; }
        public string? DriverLicenseImageLocalPath { get; set; }
    }
}
