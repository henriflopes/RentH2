using System.ComponentModel.DataAnnotations;
using RentH2.Services.OrderAPI.Utility;

namespace RentH2.Services.OrderAPI.Models.Dto
{
    public class MotorcycleDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "You must provide the type")]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        public string Year { get; set; }

        [Required(ErrorMessage = "The number plate is required to identify the vehicle")]
        [Display(Name = "Number Plate")]
        public string NumberPlate { get; set; }

        [Required(ErrorMessage = "You must add the location of the motorcycle")]
        public string? Location { get; set; }

        public string Status { get; set; } = RentStatus.Available;
    }
}
