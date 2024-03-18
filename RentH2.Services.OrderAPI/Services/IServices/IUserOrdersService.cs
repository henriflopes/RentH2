using RentH2.Services.OrderAPI.Models;

namespace RentH2.Services.OrderAPI.Services.IServices
{
	public interface IUserOrdersService
	{
        Task<List<UserOrders>> GetAsync();
        Task<UserOrders> GetAsync(string id);
        Task CreateAsync(UserOrders order);
        Task UpdateAsync(UserOrders order);
        Task RemoveAsync(string id);
    }
}
