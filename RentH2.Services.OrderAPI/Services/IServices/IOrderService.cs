using RentH2.Services.OrderAPI.Models;

namespace RentH2.Services.OrderAPI.Services.IServices
{
	public interface IOrderService
	{
        Task<List<Order>> GetAsync();
        Task<Order> GetAsync(string id);
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task RemoveAsync(string id);
        Task<List<Order>> GetAllByStatusAsync(List<string> rentStatus);

    }
}
