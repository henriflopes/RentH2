using RentH2.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class MotorcycleDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Você deve informar o tipo da motocicleta")]
        [Display(Name = "Modelo")]
        public string? Type { get; set; }

		[Required(ErrorMessage = "Informar o ano de fabricação")]
		[Display(Name = "Ano de Fabricação")]
		public string Year { get; set; }

		[Required(ErrorMessage = "O numero da placa é necessário para identificar a motocicleta")]
        [Display(Name = "Placa")]
        public string NumberPlate { get; set; }

        [Required(ErrorMessage = "Você deve informar a localização da motocicleta")]
		[Display(Name = "Localização")]
		public string? Location { get; set; }

        [Required(ErrorMessage = "Um status deve ser informado")]
        public string Status { get; set; } = RentStatus.Available;
    }
}
