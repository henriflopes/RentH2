using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentH2.Services.OrderAPI.Models;
using RentH2.Services.OrderAPI.Models.Dto;
using RentH2.Services.OrderAPI.Services.IServices;
using RentH2.Services.OrderAPI.Utility;

namespace RentH2.Services.UserOrdersAPI.Controllers
{
	[Route("api/userOrders")]
	[ApiController]
	//[Authorize(Roles = Roles.Administrator)]
	public class UserOrdersAPIController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ResponseDto _response;
		private readonly IUserOrdersService _userOrdersService;
		private readonly IRentService _ridersRentsService;

		public UserOrdersAPIController(IUserOrdersService userOrdersService, IRentService ridersRentsService,IMapper mapper) 
		{
			_userOrdersService = userOrdersService;
			_ridersRentsService = ridersRentsService;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public async Task<ResponseDto> Get()
		{
			try
			{
				List<UserOrders> userOrders = await _userOrdersService.GetAsync();
				_response.Result = _mapper.Map<IEnumerable<UserOrdersDto>>(userOrders);
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
				UserOrders userOrders = await _userOrdersService.GetAsync(id);
				_response.Result = _mapper.Map<UserOrdersDto>(userOrders);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPost]
		public async Task<ResponseDto> Post(UserOrdersDto userOrdersDto)
		{
			try
			{
				UserOrders userOrders = _mapper.Map<UserOrders>(userOrdersDto);
				await _userOrdersService.CreateAsync(userOrders);
				_response.Result = _mapper.Map<UserOrdersDto>(userOrders);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = HandleErrors.Message(ex.Message);
			}

			return _response;
		}

		[HttpPut]
		public async Task<ResponseDto> Put(UserOrdersDto userOrdersDto)
		{
			try
			{
				UserOrders userOrders = _mapper.Map<UserOrders>(userOrdersDto);

				UserOrders exists = await _userOrdersService.GetAsync(userOrders.Id);

				if (exists != null)
				{
					await _userOrdersService.UpdateAsync(userOrders);
					_response.Result = _mapper.Map<UserOrdersDto>(userOrders);
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
			//UserOrders userOrders = await _userOrdersService.GetAsync(id);

			//try
			//{
			//	if (userOrders != null)
			//	{
			//		try
			//		{
			//			var existsHist = await _ridersRentsService.GetOneByUserOrdersIdAsync(id);

			//			if (existsHist != null)
			//			{

			//				userOrders.Status = RentStatus.Deleted;
			//				await _userOrdersService.UpdateAsync(userOrders);
			//			}
			//			else
			//			{
			//				await _userOrdersService.RemoveAsync(id);
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
