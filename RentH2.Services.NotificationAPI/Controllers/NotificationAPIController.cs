using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RentH2.Services.NotificationAPI.Models;
using RentH2.Services.NotificationAPI.Models.Dto;
using RentH2.Services.NotificationAPI.Services.IServices;
using RentH2.Services.NotificationAPI.Utility;

namespace RentH2.Services.NotificationAPI.Controllers
{
	[Route("api/notification")]
	[ApiController]
	[Authorize(Roles = Roles.Administrator)]
	public class NotificationAPIController : ControllerBase
	{
		//private readonly IMapper _mapper;
		//private readonly ResponseDto _response;
		//private readonly INotificationService _notificationService;
		//private readonly IConfiguration _configuration;

		//public NotificationAPIController(INotificationService notificationService, IConfiguration configuration, IMapper mapper)
		//{
		//	_notificationService = notificationService;
		//	_configuration = configuration;
		//	_mapper = mapper;
		//	_response = new ResponseDto();
		//}

		//[HttpGet]
		//public async Task<ResponseDto> Get()
		//{
		//	try
		//	{
		//		List<Notification> notifications = await _notificationService.GetAsync();
		//		_response.Result = _mapper.Map<IEnumerable<NotificationDto>>(notifications);
		//	}
		//	catch (Exception ex)
		//	{
		//		_response.IsSuccess = false;
		//		_response.Message = ex.Message;
		//	}

		//	return _response;
		//}

		//[HttpGet]
		//[Route("{id}")]
		//public async Task<ResponseDto> Get(string id)
		//{
		//	try
		//	{
		//		Notification notification = await _notificationService.GetAsync(id);
		//		_response.Result = _mapper.Map<NotificationDto>(notification);
		//	}
		//	catch (Exception ex)
		//	{
		//		_response.IsSuccess = false;
		//		_response.Message = ex.Message;
		//	}

		//	return _response;
		//}

		//[HttpPost("GetAllByStatusAsync")]
		//public async Task<ResponseDto> GetAllByStatusAsync([FromBody] List<string> rentStatus)
		//{
		//	try
		//	{
		//		List<Notification> notifications = await _notificationService.GetAllByStatusAsync(rentStatus);
		//		_response.Result = _mapper.Map<List<NotificationDto>>(notifications);
		//	}
		//	catch (Exception ex)
		//	{
		//		_response.IsSuccess = false;
		//		_response.Message = ex.Message;
		//	}

		//	return _response;
		//}

		//[HttpPost]
		//public async Task<ResponseDto> Post(NotificationDto notificationDto)
		//{
		//	try
		//	{
		//		Notification notification = _mapper.Map<Notification>(notificationDto);
		//		await _notificationService.CreateAsync(notification);
		//		var resultNotificationDto = _mapper.Map<NotificationDto>(notification);

		//		string topicName = _configuration.GetValue<string>("TopicAndQueueNames:NotificationCreatedTopic");
		//		_messageBus.PostMessage(resultNotificationDto, topicName);

		//		_response.Result = resultNotificationDto;
		//	}
		//	catch (Exception ex)
		//	{
		//		_response.IsSuccess = false;
		//		_response.Message = HandleErrors.Message(ex.Message);
		//	}

		//	return _response;
		//}

		//[HttpPut]
		//public async Task<ResponseDto> Put(NotificationDto notificationDto)
		//{
		//	try
		//	{
		//		Notification notification = _mapper.Map<Notification>(notificationDto);

		//		Notification exists = await _notificationService.GetAsync(notification.Id);

		//		if (exists != null)
		//		{
		//			await _notificationService.UpdateAsync(notification);
		//			_response.Result = _mapper.Map<NotificationDto>(notification);
		//		}
		//		else
		//		{
		//			_response.IsSuccess = false;
		//			_response.Message = "Not Found";
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_response.IsSuccess = false;
		//		_response.Message = HandleErrors.Message(ex.Message);
		//	}

		//	return _response;
		//}

		//[HttpDelete]
		//[Route("{id}")]
		//public async Task<ResponseDto> Delete(string id)
		//{
		//	Notification notification = await _notificationService.GetAsync(id);

		//	try
		//	{
		//		if (notification != null)
		//		{
		//			try
		//			{
		//				UserNotifications userNotifications = await _userNotificationsService.GetAsync(id);
		//				if (userNotifications != null)
		//				{
		//					notification.Status = OrderStatus.Deleted;
		//					userNotifications?.Notifications?.Remove(notification);
		//					userNotifications?.Notifications?.Add(notification);
		//					await _notificationService.UpdateAsync(notification);
		//				}
		//				else
		//				{
		//					await _notificationService.RemoveAsync(id);
		//				}

		//			}
		//			catch (MongoException ex)
		//			{
		//				throw;
		//			}
		//		}
		//		else
		//		{
		//			_response.IsSuccess = false;
		//			_response.Message = "Not Found";
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		_response.IsSuccess = false;
		//		_response.Message = ex.Message;
		//	}

		//	return _response;
		//}
	}
}
