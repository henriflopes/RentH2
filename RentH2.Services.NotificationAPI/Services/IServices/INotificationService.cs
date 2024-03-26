using RentH2.Services.NotificationAPI.Models;
using RentH2.Services.NotificationAPI.Models.Dto;

namespace RentH2.Services.NotificationAPI.Services.IServices
{
    public interface INotificationService
    {
        Task LogNotificationPlaced(OrderDto orderDto);
    }
}