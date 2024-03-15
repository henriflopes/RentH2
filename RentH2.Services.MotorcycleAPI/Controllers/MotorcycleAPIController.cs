using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RentH2.MotorcycleAPI.Utility;
using RentH2.Services.MotorcycleAPI.Models;
using RentH2.Services.MotorcycleAPI.Models.Dto;
using RentH2.Services.MotorcycleAPI.Services.IService;
using RentH2.Services.MotorcycleAPI.Utility;
using RentH2.Web.Services.IServices;

namespace RentH2.Services.MotorcycleAPI.Controllers
{
    [Route("api/motorcycle")]
	[ApiController]
	//[Authorize(Roles = Roles.Administrator)]
	public class MotorcycleAPIController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ResponseDto _response;
		private readonly IMotorcycleService _motorcycleService;
		private readonly IRidersRentsService _ridersRentsService;

		public MotorcycleAPIController(IMotorcycleService motorcycleService, IRidersRentsService ridersRentsService,IMapper mapper) 
		{
			_motorcycleService = motorcycleService;
			_ridersRentsService = ridersRentsService;
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

		[HttpPost("GetAllByStatusAsync")]
		public async Task<ResponseDto> GetAllByStatusAsync([FromBody] List<string> rentStatus)
		{
			try
			{
				List<Motorcycle> motorcycles = await _motorcycleService.GetAllByStatusAsync(rentStatus);
				_response.Result = _mapper.Map<List<MotorcycleDto>>(motorcycles);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}


		[HttpPost]
		public async Task<ResponseDto> Post(MotorcycleDto motorcycleDto)
		{
			try
			{
				Motorcycle motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);
				await _motorcycleService.CreateAsync(motorcycle);
				_response.Result = _mapper.Map<MotorcycleDto>(motorcycle);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = HandleErrors.Message(ex.Message);
			}

			return _response;
		}

		[HttpPut]
		public async Task<ResponseDto> Put(MotorcycleDto motorcycleDto)
		{
			try
			{
				Motorcycle motorcycle = _mapper.Map<Motorcycle>(motorcycleDto);

				Motorcycle exists = await _motorcycleService.GetAsync(motorcycle.Id);

				if (exists != null)
				{
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
				_response.Message = HandleErrors.Message(ex.Message);
			}

			return _response;
		}

		[HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(string id)
		{
			Motorcycle motorcycle = await _motorcycleService.GetAsync(id);

			try
			{
				if (motorcycle != null)
				{
					try
					{
						var existsHist = await _ridersRentsService.GetOneByMotorcycleIdAsync(id);

						if (existsHist != null)
						{

							motorcycle.Status = RentStatus.Deleted;
							await _motorcycleService.UpdateAsync(motorcycle);
						}
						else
						{
							await _motorcycleService.RemoveAsync(id);
						}

					}
					catch (MongoException ex)
					{

						throw;
					}
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
