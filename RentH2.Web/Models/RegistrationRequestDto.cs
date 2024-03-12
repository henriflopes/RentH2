using RentH2.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class RegistrationRequestDto
    {
		[Required(ErrorMessage = "Você deve informar o Nome")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Você deve informar uma senha")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Você deve informar o seu CNPJ")]
		public string DocumentId { get; set; }
		[Required(ErrorMessage = "Você deve informar sua data de nascimento")]
		[Display(Name = "Data de Nascimento")]
		public DateTime DateBirth { get; set; }
		[Required(ErrorMessage = "Você deve informar o e-mail")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Você deve informar o Numero de Telefone")]
		[Display(Name = "Numero de Telefone")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Você deve informar o numero da carteira de motorista")]
		[Display(Name = "Numero Carteira Motorista")]
		public string DriverLicenseId { get; set; }
		[Required(ErrorMessage = "Você deve informar a categoria da sua motorista")]
		[Display(Name = "Categoria Carteira Motorista")]
		public string DriverLicenseClass { get; set; }
		public string? DriverLicenseImgUrl { get; set; }
		public string? DriverLicenseImgPath { get; set; }
		[Required(ErrorMessage = "Você deve selecionar um perfil")]
		public string? Role { get; set; }
		[MaxFileSize(1)]
		[AllowedExtensions(new string[] { ".png", ".bmp" })]
		public IFormFile? Image { get; set; }

	}
}
