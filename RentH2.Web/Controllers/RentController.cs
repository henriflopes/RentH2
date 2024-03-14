using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace RentH2.Web.Controllers
{


	public class RentController : Controller
	{
		private readonly IRentService _rentService;
		private readonly IAuthService _authService;
		private readonly IMotorcycleService _motorcycleService;

		public RentController(IRentService rentService, IAuthService authService, IMotorcycleService motorcycleService)
		{
			_rentService = rentService;
			_authService = authService;
			_motorcycleService = motorcycleService;
		}

		public async Task<IActionResult> Index()
		{
			var userDetails = await UserDetails();

			return View(userDetails);
		}

		public async Task<IActionResult> RentReview(string rentAgendaDto)
		{
			var selectedPlan = JsonConvert.DeserializeObject<RentAgendaDto>(rentAgendaDto);
			var rentAgenda = GetAvalaiblePlans(selectedPlan.StartDate).GetAwaiter().GetResult()
				.Where( x => x.Plan.TotalDays == selectedPlan.Plan.TotalDays).FirstOrDefault();
			
			var userDetails = await UserDetails();
			
			var motorcycle = await GetMotorcycleByIdAsync(rentAgenda.MotorcycleId);
			
			if (motorcycle == null || userDetails == null || rentAgenda == null)
				return RedirectToAction(nameof(Index));

			RentDto rentDto = new()
			{
				StartDate = rentAgenda.StartDate,
				EndDate = rentAgenda.EndDate.Value,
				Total = rentAgenda.Plan.TotalPrice,
				TotalExpected = rentAgenda.Plan.TotalPrice,
				User = userDetails,
				Plan = rentAgenda.Plan,
				Motorcycle = motorcycle
			};
			rentDto.EndDateExpected = rentDto.EndDate;

			return View(rentDto);
		}


		[HttpGet]
		public async Task<IActionResult> SelectPlan(DateTime startDate)
		{
			RentAgendaDto rentAgenda = new() { StartDate = startDate };
			List<RentAgendaDto>? plans = await GetAvalaiblePlans(startDate);

			if (plans != null)
			{
				if (!plans.Where(x => x.Plan?.Status == RentStatus.Available).Any()) 
				{
					TempData["error"] = "Não existe motos disponíveis para esta data. Por favor selecione uma outra.";
					return RedirectToAction(nameof(Index));
				}

				return View(plans);
			}
			else
			{
				return NotFound();
			}
		}

		private async Task<List<RentAgendaDto>?> GetAvalaiblePlans(DateTime startDate)
		{
			RentAgendaDto rentAgenda = new() { StartDate = startDate };
			List<RentAgendaDto> plans = new List<RentAgendaDto>();
			ResponseDto response = await _rentService.GetAvalaiblePlans(rentAgenda);

			if (response != null && response.IsSuccess)
			{
				plans = JsonConvert.DeserializeObject<List<RentAgendaDto>>(Convert.ToString(response.Result));
			}

			return plans;
		}


		private async Task<ApplicationUserDto?> UserDetails()
		{
			var userId = User.Claims.Where(w => w.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
			ResponseDto? response = await _authService.GetUserDetailsByUserId(userId);
			if (response != null && response.IsSuccess)
			{
				ApplicationUserDto? model = JsonConvert.DeserializeObject<ApplicationUserDto?>(Convert.ToString(response.Result));
				return model;
			}
			else
			{
				TempData["error"] = response?.Message;
				return null;
			}
		}

		private async Task<MotorcycleDto> GetMotorcycleByIdAsync(string motorcycleId)
		{
			ResponseDto responsePlan = await _motorcycleService.GetMotorcycleByIdAsync(motorcycleId);
			if (responsePlan != null && responsePlan.IsSuccess)
			{
				var motorcycle = JsonConvert.DeserializeObject<MotorcycleDto>(Convert.ToString(responsePlan.Result));
				return motorcycle;
			}
			else
			{
				TempData["error"] = "Ocorreu algum erro ao consultar a motocycleta.";
				return null;
			}
		}
	}
}
