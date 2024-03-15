using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentH2.Services.RentAPI.Models;
using RentH2.Services.RentAPI.Models.Dto;
using RentH2.Services.RentAPI.Services.IService;
using RentH2.Services.RentAPI.Utility;

namespace RentH2.Services.RentAPI.Controllers
{
	[Route("api/rent")]
	[ApiController]
	//[Authorize]
	public class RentAPIController : ControllerBase
	{
		private readonly ResponseDto _response;
		private readonly IRentService _rentService;
		private readonly IMotorcycleService _motorcycleService;
		private readonly IPlanService _planService;
		private readonly IRidersRentsService _ridersRentsService;
		private readonly IMapper _mapper;

		public RentAPIController(IRentService rentService, IMotorcycleService motorcycleService, IPlanService planService, IRidersRentsService ridersRentsService,IMapper mapper)
		{
			_rentService = rentService;
			_motorcycleService = motorcycleService;
			_planService = planService;
			_ridersRentsService = ridersRentsService;
			_mapper = mapper;
			_response = new ResponseDto();
		}

		[HttpGet]
		public async Task<ResponseDto> GetAllRent()
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

		[HttpPost("GetAllRentedByExpectedDateAsync")]
		public async Task<ResponseDto> GetAllRentedByExpectedDateAsync([FromBody] RentAgendaDto rentAgendaDto)
		{
			try
			{
				RentAgenda rentAgenda = _mapper.Map<RentAgenda>(rentAgendaDto);
				var rentedAgenda = await _rentService.GetAllRentedByExpectedDateAsync(rentAgenda);
				_response.Result = _mapper.Map<IEnumerable<RentAgendaDto>>(rentedAgenda);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPost("GetAvalaiblePlans")]
		public async Task<ResponseDto> GetAvalaiblePlans([FromBody] RentAgendaDto rentAgendaDto)
		{
			try
			{
				List<RentAgendaDto> RentAgendaDtoResult = [];
				RentAgendaDto resultItem;

				var rentAgenda = _mapper.Map<RentAgenda>(rentAgendaDto);
				var plans = await _planService.GetAllByStatusAsync([RentStatus.Available]);

				foreach (var plan in plans.OrderBy(o => o.TotalDays))
				{
					rentAgenda.EndDate = rentAgenda.StartDate.AddDays(plan.TotalDays);
					var motorcycle = await _motorcycleService.GetOneAvailable(rentAgenda);
					if (motorcycle == null)
					{
						plan.Status = RentStatus.Unavailable;
					}

					resultItem = new RentAgendaDto
					{
						StartDate = rentAgenda.StartDate,
						EndDate = rentAgenda.EndDate,
						TotalDaysInRow = plan.TotalDays,
						MotorcycleId = motorcycle?.Id,
						MotorcycleStatus = motorcycle?.Status,
						Plan = plan
					};

					RentAgendaDtoResult.Add(resultItem);
				}

				_response.Result = RentAgendaDtoResult;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPost("RentAsync")]
		public async Task<ResponseDto> RentAsync([FromBody] RentDto rentDto)
		{
			try
			{
				Rent rent = _mapper.Map<Rent>(rentDto);

				RentAgenda rentAgenda = _mapper.Map<RentAgenda>(rent);

				var motorcycle = await _motorcycleService.GetOneAvailable(rentAgenda);
				if (motorcycle == null)
				{
					_response.IsSuccess = false;
					_response.Message = "Não há motos disponíveis para este período!";

					return _response;
				}

				var motorcycleDto = _mapper.Map<Motorcycle>(motorcycle);
				motorcycleDto.Status = RentStatus.Rented;
				await _motorcycleService.UpdateAsync(motorcycleDto);
				rent.Motorcycle = motorcycleDto;

				var result = await _rentService.CreateAsync(rent);

				RidersRents ridersRents = new RidersRents
				{
					RentId = result.Id,
					MotorcycleId = rent.Motorcycle.Id,
					PlanId = rent.Plan.Id,
					UserId = rent.User.Id,
					TimeStamp = DateTime.UtcNow
				};

				await _ridersRentsService.CreateAsync(ridersRents);

				_response.Result = _mapper.Map<RentDto>(rent);
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
