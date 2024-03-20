using RentH2.Web.Models;

namespace RentH2.Web.Services.IServices
{
	public interface IOrderService
	{
		Task<ResponseDto?> GetAllOrdersAsync();
		Task<ResponseDto?> GetOrderByIdAsync(string id);
		Task<ResponseDto?> CreateOrderAsync(OrderDto orderDto);
		Task<ResponseDto?> DeleteOrderAsync(string id);
		Task<ResponseDto?> UpdateOrderAsync(OrderDto orderDto);
	}
}
