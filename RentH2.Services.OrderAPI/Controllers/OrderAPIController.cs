using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RentH2.Services.OrderAPI.Models;
using RentH2.Services.OrderAPI.Models.Dto;
using RentH2.Services.OrderAPI.Services.IServices;
using RentH2.Services.OrderAPI.Utility;

namespace RentH2.Services.OrderAPI.Controllers
{
	[Route("api/order")]
	[ApiController]
	//[Authorize(Roles = Roles.Administrator)]
	public class OrderAPIController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ResponseDto _response;
		private readonly IOrderService _orderService;
		private readonly IRidersRentsService _ridersRentsService;

		public OrderAPIController(IOrderService orderService, IRidersRentsService ridersRentsService,IMapper mapper) 
		{
			_orderService = orderService;
			_ridersRentsService = ridersRentsService;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public async Task<ResponseDto> Get()
		{
			try
			{
				List<Order> orders = await _orderService.GetAsync();
				_response.Result = _mapper.Map<IEnumerable<OrderDto>>(orders);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ResponseDto> Get(string id)
		{
			try
			{
				Order order = await _orderService.GetAsync(id);
				_response.Result = _mapper.Map<OrderDto>(order);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPost("GetAllByStatusAsync")]
		public async Task<ResponseDto> GetAllByStatusAsync([FromBody] List<string> rentStatus)
		{
			try
			{
				List<Order> orders = await _orderService.GetAllByStatusAsync(rentStatus);
				_response.Result = _mapper.Map<List<OrderDto>>(orders);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}


		[HttpPost]
		public async Task<ResponseDto> Post(OrderDto orderDto)
		{
			try
			{
				Order order = _mapper.Map<Order>(orderDto);
				await _orderService.CreateAsync(order);
				_response.Result = _mapper.Map<OrderDto>(order);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = HandleErrors.Message(ex.Message);
			}

			return _response;
		}

		[HttpPut]
		public async Task<ResponseDto> Put(OrderDto orderDto)
		{
			try
			{
				Order order = _mapper.Map<Order>(orderDto);

				Order exists = await _orderService.GetAsync(order.Id);

				if (exists != null)
				{
					await _orderService.UpdateAsync(order);
					_response.Result = _mapper.Map<OrderDto>(order);
				}
				else
				{
					_response.IsSuccess = false;
					_response.Message = "Not Found";
				}
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = HandleErrors.Message(ex.Message);
			}

			return _response;
		}

		[HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(string id)
		{
			//Order order = await _orderService.GetAsync(id);

			//try
			//{
			//	if (order != null)
			//	{
			//		try
			//		{
			//			var existsHist = await _ridersRentsService.GetOneByOrderIdAsync(id);

			//			if (existsHist != null)
			//			{

			//				order.Status = RentStatus.Deleted;
			//				await _orderService.UpdateAsync(order);
			//			}
			//			else
			//			{
			//				await _orderService.RemoveAsync(id);
			//			}

			//		}
			//		catch (MongoException ex)
			//		{

			//			throw;
			//		}
			//	}
			//	else
			//	{
			//		_response.IsSuccess = false;
			//		_response.Message = "Not Found";
			//	}
			//}
			//catch (Exception ex)
			//{
			//	_response.IsSuccess = false;
			//	_response.Message = ex.Message;
			//}

			//return _response;

			return new();
		}
	}
}
