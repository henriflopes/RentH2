﻿using RentH2.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class MotorcycleDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Você deve informar o tipo da motocicleta")]
        [Display(Name = "Type")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "O numero da placa é necessário para identificar a motocicleta")]
        [Display(Name = "Number Plate")]
        public string NumberPlate { get; set; }

        [Required(ErrorMessage = "Você deve informar a localização da motocicleta")]
        public string? Location { get; set; }

        [Required(ErrorMessage = "Um status deve ser informado")]
        public string Status { get; set; } = RentStatus.Available;
    }
}