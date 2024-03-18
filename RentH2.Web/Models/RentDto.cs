using Microsoft.AspNetCore.Mvc;
using RentH2.Web.Utility;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RentH2.Web.Models
{
	public class RentDto
    {

        public string? Id { get; set; }
        [Required(ErrorMessage = "Informar uma data de inicio.")]
        [Display(Name = "Data de Início")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data de Término")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public DateTime EndDateExpected { get; set; }
		[Display(Name = "Dias utilizados até o momento.")]
		public double UsedDays { get; set; }
		[Display(Name = "Valor Total hoje")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }
        public double TotalExpected { get; set; }
        public string Status { get; set; } = RentStatus.Available;
        [Display(Name = "Data Hora da Solicitação")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [DataType(DataType.DateTime)]
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public ApplicationUserDto User { get; set; }
        public MotorcycleDto Motorcycle { get; set; }
        public PlanDto Plan { get; set; }
    }
}