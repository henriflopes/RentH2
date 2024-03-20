using Humanizer.Localisation;
using Newtonsoft.Json.Linq;
using RentH2.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Web.Models
{
    public class OrderDto
    {
        [Display(Name = "Código do Pedido")]
        public string? Id { get; set; }

        [Display(Name = "Código do Usuário")]
        public string? UserId { get; set; }

        [Display(Name = "Taxa de entrega")]
        [Required(ErrorMessage = "Você deve informar o valor.")]
        [DataType(DataType.Currency)]
        
        public double ShippingTax { get; set; }

        [Required(ErrorMessage = "Você deve informar o valor.")]
        public string ShippingTaxTemp { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Display(Name = "Data de Criação")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [DataType(DataType.DateTime)]
        public DateTime Timestamp { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Você deve selecionar uma opção.")]
        public string Status { get; set; } = OrderStatus.Available;
    }
}
