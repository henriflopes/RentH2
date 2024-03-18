using RentH2.Services.OrderAPI.Utility;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Services.OrderAPI.Models.Dto
{
	public class OrderDto
	{
		[Display(Name = "Código do Pedido")]
		public string? Id { get; set; }

		[Display(Name = "Código do Usuário")]
		public string? UserId { get; set; }

		[Display(Name = "Taxa de entrega")]
		[Required(ErrorMessage = "Você deve informar o valor.")]
		public double ShippingTax { get; set; }

		[Display(Name = "Data de Criação")]
		public DateTime Timestamp { get; set; } = DateTime.Now;

		[Display(Name = "Status")]
		public string Status { get; set; } = OrderStatus.Available;
	}
}
