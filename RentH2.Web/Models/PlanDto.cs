using RentH2.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class PlanDto
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Informar uma descriçao para o plano.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "É necessário informar o total de dias.")]
        public int TotalDays { get; set; }

        [Required(ErrorMessage = "É necessário informar o preço diário.")]
        public double DailyPrice { get; set; }

        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "É necessário informar uma multa por antecipação.")]
        public double FineAntecipated { get; set; }

        [Required(ErrorMessage = "É necessário informar uma multa por atraso.")]
        public double FineDelayed { get; set; }

        public string Status { get; set; } = RentStatus.Available;
    }
}