using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Models.Dto;
using RentH2.Services.RentAPI.Services.IService;

namespace RentH2.Services.RentAPI.Controllers
{
	[Route("api/rent")]
	[ApiController]
	[Authorize]
	public class RentAPIController : ControllerBase
	{
		private readonly ResponseDto _response;
		private readonly IRentService _rentService;
		private readonly IMapper _mapper;

		public RentAPIController(IRentService rentService, IMapper mapper)
		{
			_rentService = rentService;
			_mapper = mapper;
			_response = new ResponseDto();
		}


		[HttpGet]
		public async Task<ResponseDto> Get()
		{
			try
			{
				List<Rent> rents = await _rentService.GetAsync();
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
				Rent rent = await _rentService.GetAsync(id);
				_response.Result = _mapper.Map<RentDto>(rent);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}


		[HttpPost]
		public async Task<ResponseDto> Post(RentDto rentDto)
		{
			try
			{
				Rent rent = _mapper.Map<Rent>(rentDto);
				await _rentService.CreateAsync(rent);
				_response.Result = _mapper.Map<RentDto>(rent);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPut]
		public async Task<ResponseDto> Put(RentDto rentDto)
		{
			try
			{
				Rent rent = _mapper.Map<Rent>(rentDto);

				Rent exists = await _rentService.GetAsync(rent.Id);

				if (exists != null)
				{
					await _rentService.UpdateAsync(rent);
					_response.Result = _mapper.Map<RentDto>(rent);
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
			Rent rent = await _rentService.GetAsync(id);

			try
			{
				if (rent != null)
				{
					await _rentService.RemoveAsync(id);
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
