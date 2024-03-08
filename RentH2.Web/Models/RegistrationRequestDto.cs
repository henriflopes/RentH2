using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class RegistrationRequestDto
    {
        [Required(ErrorMessage = "Você deve informar o e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Você deve informar o Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Você deve informar o Numero de Telefone")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Você deve informar uma senha")]
        public string Password { get; set; }
		[Required(ErrorMessage = "Você deve selecionar um perfil")]
		public string? Role { get; set; }
    }
}
