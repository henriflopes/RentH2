//using RentH2.Services.NotificationAPI.Services.IServices;

//public class OrderService : IOrderService
//{

//    private readonly IHttpClientFactory _httpClientFactory;

//    public OrderService(IHttpClientFactory httpClientFactory)
//    {
//        _httpClientFactory = httpClientFactory;
//    }

//    public async Task<List<RidersRentsDto>> GetAllUserWithRentedMotorcycleAsync()
//    {
//        var client = _httpClientFactory.CreateClient("Order");
//        var response = await client.GetAsync($"/api/ridersrents/GetAllUserWithRentedMotorcycleAsync");
//        var apiContent = await response.Content.ReadAsStringAsync();

//        var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

//        if (resp != null && resp.IsSuccess)
//        {
//            return JsonConvert.DeserializeObject<List<RidersRentsDto>>(Convert.ToString(resp.Result));
//        }

//        return [];
//    }
//}