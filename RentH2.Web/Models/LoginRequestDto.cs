using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Você deve informar o nome de usuário")]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Você deve informar uma senha")]
        public string Password { get; set; }
    }
}
