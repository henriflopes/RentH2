using RentH2.Services.NotificationAPI.Models;

namespace RentH2.Services.NotificationAPI.Services.IServices
{
	public interface IOrderService
	{
        Task<List<Notification>> GetAsync();
        Task<Notification> GetAsync(string id);
        Task CreateAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task RemoveAsync(string id);
        Task<List<Notification>> GetAllByStatusAsync(List<string> rentStatus);

    }
}
