using System.ComponentModel.DataAnnotations;

namespace RentH2.Services.OrderAPI.Models.Dto
{
	public class UserOrdersDto
	{
		public string? Id { get; set; }

		[Display(Name = "Código do Usuário")]
		public string? UserId { get; set; }
		
		[Display(Name = "Pedidos")]
		public List<OrderDto>? Orders { get; set; }
	}
}
