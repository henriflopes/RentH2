using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;

namespace RentH2.Web.Services
{
    public class OrderService : IOrderService
    {
		private readonly IBaseService _baseService;

		public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
		}

		public async Task<ResponseDto?> CreateOrderAsync(OrderDto orderDto)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = orderDto,
				Url = SD.OrderAPIBase
			});
		}

		public async Task<ResponseDto?> DeleteOrderAsync(string id)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.OrderAPIBase + id
			});
		}

        public async Task<ResponseDto?> GetAllOrdersAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase
			});
        }

        public async Task<ResponseDto?> GetOrderByIdAsync(string id)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + id
            });
		}

		public async Task<ResponseDto?> UpdateOrderAsync(OrderDto orderDto)
        {
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.PUT,
				Data = orderDto,
				Url = SD.OrderAPIBase
			});
		}
    }
}
