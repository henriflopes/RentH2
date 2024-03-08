using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using RentH2.MotorcycleAPI.Utility;
using RentH2.Services.MotorcycleAPI.Models;
using RentH2.Services.MotorcycleAPI.Models.Dto;
using RentH2.Services.MotorcycleAPI.Services.IService;

namespace RentH2.Services.MotorcycleAPI.Controllers
{
	[Route("api/motorcycle")]
	[ApiController]
	public class MotorcycleAPIController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ResponseDto _response;
		private readonly IMotorcycleService _motorcycleService;

		public MotorcycleAPIController(IMotorcycleService motorcycleService, IMapper mapper) 
		{
			_motorcycleService = motorcycleService;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public async Task<ResponseDto> Get()
		{
			try
			{
				List<Motorcycle> motorcycles = await _motorcycleService.GetAsync();
				_response.Result = _mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles);
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
				Motorcycle motorcycle = await _motorcycleService.GetAsync(id);
				_response.Result = _mapper.Map<MotorcycleDto>(motorcycle);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}


		[HttpPost]
		//[Authorize(Roles = Roles.Administrator)]
		public async Task<ResponseDto> Post(MotorcycleDto motorcycleDto)
		{
			try
			{
				Motorcycle motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);
				var exists = await _motorcycleService.ExistsNumberPlate(motorcycle);

				if (exists)
				{
					_response.IsSuccess = false;
					_response.Message = "There is already a Number Plate like yours in our database!";
					return _response;
				}

				await _motorcycleService.CreateAsync(motorcycle);
				_response.Result = _mapper.Map<MotorcycleDto>(motorcycle);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPut]
		//[Authorize(Roles = Roles.Administrator)]
		public async Task<ResponseDto> Put(MotorcycleDto motorcycleDto)
		{
			try
			{
				Motorcycle motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);

				Motorcycle exists = await _motorcycleService.GetAsync(motorcycle.Id);

				if (exists != null)
				{
					var existsNumberPlate = await _motorcycleService.ExistsNumberPlate(motorcycle);

					if (existsNumberPlate)
					{
						_response.IsSuccess = false;
						_response.Message = "There is already a Number Plate like yours in our database!";
						return _response;
					}

					await _motorcycleService.UpdateAsync(motorcycle);
					_response.Result = _mapper.Map<MotorcycleDto>(motorcycle);
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
        //[Authorize(Roles = Roles.Administrator)]
        public async Task<ResponseDto> Delete(string id)
		{
			Motorcycle motorcycle = await _motorcycleService.GetAsync(id);

			try
			{
				if (motorcycle != null)
				{
					await _motorcycleService.RemoveAsync(id);
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
