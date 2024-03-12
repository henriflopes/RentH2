using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentH2.Services.PlanAPI.Models;
using RentH2.Services.PlanAPI.Models.Dto;
using RentH2.Services.PlanAPI.Services.IService;

namespace RentH2.Services.PlanAPI.Controllers
{
	[Route("api/plan")]
	[ApiController]
	public class PlanAPIController : ControllerBase
	{
		private readonly ResponseDto _response;
		private readonly IPlanService _planService;
		private readonly IMapper _mapper;

		public PlanAPIController(IPlanService planService, IMapper mapper)
		{
			_planService = planService;
			_mapper = mapper;
			_response = new ResponseDto();
		}


		[HttpGet]
		public async Task<ResponseDto> Get()
		{
			try
			{
				List<Plan> plans = await _planService.GetAsync();
				_response.Result = _mapper.Map<IEnumerable<PlanDto>>(plans);
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
				Plan plan = await _planService.GetAsync(id);
				_response.Result = _mapper.Map<PlanDto>(plan);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}


		[HttpPost]
		public async Task<ResponseDto> Post(PlanDto planDto)
		{
			try
			{
				Plan plan = _mapper.Map<Plan>(planDto);
				await _planService.CreateAsync(plan);
				_response.Result = _mapper.Map<PlanDto>(plan);

			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}

			return _response;
		}

		[HttpPut]
		public async Task<ResponseDto> Put(PlanDto planDto)
		{
			try
			{
				Plan plan = _mapper.Map<Plan>(planDto);

				Plan exists = await _planService.GetAsync(plan.Id);

				if (exists != null)
				{
					await _planService.UpdateAsync(plan);
					_response.Result = _mapper.Map<PlanDto>(plan);
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
			Plan plan = await _planService.GetAsync(id);

			try
			{
				if (plan != null)
				{
					await _planService.RemoveAsync(id);
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
