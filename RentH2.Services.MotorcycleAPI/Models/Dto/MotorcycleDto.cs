using System.ComponentModel.DataAnnotations;

namespace RentH2.Services.MotorcycleAPI.Models.Dto
{
	public class MotorcycleDto
	{
		public string? Id { get; set; }

		[Required(ErrorMessage = "You must provide the make and model")]
		[Display(Name = "Make and Model")]
		public string? Model { get; set; }

		[Required(ErrorMessage = "The number plate is required to identify the vehicle")]
		[Display(Name = "Number Plate")]
		public string NumberPlate { get; set; }

		[Required(ErrorMessage = "You must add the location of the motorcycle")]
		public string? Location { get; set; }

		public bool IsBooked { get; set; } = false;
	}
}
