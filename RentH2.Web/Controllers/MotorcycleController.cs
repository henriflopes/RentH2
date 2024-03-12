using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;

namespace RentH2.Web.Controllers
{
	public class MotorcycleController : Controller
	{
		private readonly IMotorcycleService _motorcycleService;

		public MotorcycleController(IMotorcycleService motorcycleService)
		{
			_motorcycleService = motorcycleService;
		}

		public IActionResult MotorcycleIndex()
		{
			return View();
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			List<MotorcycleDto>? motorcycles = new();

			ResponseDto? response = _motorcycleService.GetAllMotorcyclesAsync().GetAwaiter().GetResult();

			if (response != null && response.IsSuccess)
			{
				motorcycles = JsonConvert.DeserializeObject<List<MotorcycleDto>?>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return Json(new { data = motorcycles });
		}



		public IActionResult MotorcycleCreate()
		{

			SeedStatusType();

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> MotorcycleCreate(MotorcycleDto model)
		{
			if (ModelState.IsValid)
			{
				ResponseDto? response = await _motorcycleService.CreateMotorcycleAsync(model);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "A Motocicleta foi cadastrada com sucesso!";
					return RedirectToAction(nameof(MotorcycleIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
					SeedStatusType();
				}
			}

			return View(model);
		}

		public async Task<IActionResult> MotorcycleEdit(string id)
		{

			ResponseDto? response = await _motorcycleService.GetMotorcycleByIdAsync(id);

			if (response != null && response.IsSuccess)
			{
				MotorcycleDto? model = JsonConvert.DeserializeObject<MotorcycleDto?>(Convert.ToString(response.Result));
				SeedStatusType();
				return View(model);
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> MotorcycleEdit(MotorcycleDto model)
		{
			if (ModelState.IsValid)
			{
				ResponseDto? response = await _motorcycleService.UpdateMotorcycleAsync(model);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "Motocicleta atualizada com sucesso!";
					return RedirectToAction(nameof(MotorcycleIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
					SeedStatusType();
				}
			}

			return View(model);
		}

		public async Task<IActionResult> MotorcycleDelete(string id)
		{

			ResponseDto? response = await _motorcycleService.GetMotorcycleByIdAsync(id);

			if (response != null && response.IsSuccess)
			{
				MotorcycleDto? model = JsonConvert.DeserializeObject<MotorcycleDto?>(Convert.ToString(response.Result));
				SeedStatusType();
				return View(model);
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> MotorcycleDelete(MotorcycleDto motorcycleDto)
		{
			if (ModelState.IsValid)
			{
				ResponseDto? response = await _motorcycleService.DeleteMotorcycleAsync(motorcycleDto.Id);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "Motocicleta excluida com sucesso!";
					return RedirectToAction(nameof(MotorcycleIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
					SeedStatusType();
				}
			}
			return NotFound(motorcycleDto);
		}

		private void SeedStatusType()
		{
			var status = new List<SelectListItem>()
			{
				new SelectListItem{ Text=RentStatus.Available, Value=RentStatus.Available},
				new SelectListItem{ Text=RentStatus.Unavailable, Value=RentStatus.Unavailable}
			};

			ViewBag.Status = status;
		}

	}
}
