using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Models.Dto;
using RentH2.Services.RentAPI.Services;
using RentH2.Services.RentAPI.Services.IService;

namespace RentH2.Services.RentAPI.Controllers
{
	[Route("api/ridersrents")]
	[ApiController]
	[Authorize]
	public class RidersRentsAPIController : ControllerBase
	{
		private readonly ResponseDto _response;
		private readonly IRidersRentsService _ridersRentsService;
		private readonly IMapper _mapper;

		public RidersRentsAPIController(IRidersRentsService ridersRentsService, IMapper mapper)
		{
			_ridersRentsService = ridersRentsService;
			_mapper = mapper;
			_response = new ResponseDto();
		}


		[HttpGet]
		public async Task<ResponseDto> Get()
		{
			try
			{
				List<RidersRents> rents = await _ridersRentsService.GetAsync();
				_response.Result = _mapper.Map<IEnumerable<RentDto>>(rents);
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
				RidersRents ridersRents = await _ridersRentsService.GetAsync(id);
				_response.Result = _mapper.Map<RentDto>(ridersRents);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}


		[HttpPost]
		public async Task<ResponseDto> Post(RidersRentsDto rentDto)
		{
			try
			{
				RidersRents ridersRents = _mapper.Map<RidersRents>(rentDto);
				await _ridersRentsService.CreateAsync(ridersRents);
				_response.Result = _mapper.Map<RidersRentsDto>(ridersRents);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPut]
		public async Task<ResponseDto> Put(RidersRentsDto ridersRentsDto)
		{
			try
			{
				RidersRents ridersRents = _mapper.Map<RidersRents>(ridersRentsDto);

				RidersRents exists = await _ridersRentsService.GetAsync(ridersRents.Id);

				if (exists != null)
				{
					await _ridersRentsService.UpdateAsync(ridersRents);
					_response.Result = _mapper.Map<RidersRentsDto>(ridersRents);
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
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ResponseDto> Delete(string id)
		{
			RidersRents ridersRents = await _ridersRentsService.GetAsync(id);

			try
			{
				if (ridersRents != null)
				{
					await _ridersRentsService.RemoveAsync(id);
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
				_response.Message = ex.Message;
			}

			return _response;
		}
	}
}
