using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;
using System.IdentityModel.Tokens.Jwt;

namespace RentH2.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;
        private readonly IAuthService _authService;

        public OrderController(IOrderService orderService, IAuthService authService)
        {
            _orderService = orderService;
            _authService = authService;
        }

        public IActionResult OrderIndex()
		{
			return View();
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			List<OrderDto>? orders = new();

			ResponseDto? response = _orderService.GetAllOrdersAsync().GetAwaiter().GetResult();

			if (response != null && response.IsSuccess)
			{
				orders = JsonConvert.DeserializeObject<List<OrderDto>?>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return Json(new { data = orders });
		}

		public IActionResult OrderCreate()
		{

			SeedStatusType();

			return View();
		}


		[HttpPost]
		public async Task<IActionResult> OrderCreate(OrderDto model)
		{
			var applicationUserDto = await UserDetails();
			model.UserId = applicationUserDto.Id;
            model.Timestamp = DateTime.Now;
            model.ShippingTax = Convert.ToDouble(model.ShippingTaxTemp);

            if (ModelState.IsValid)
			{
				ResponseDto? response = await _orderService.CreateOrderAsync(model);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "O Pedido foi cadastrada com sucesso!";
					return RedirectToAction(nameof(OrderIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
				}
			}

            SeedStatusType();
            return View(model);
		}

		public async Task<IActionResult> OrderEdit(string id)
		{

			ResponseDto? response = await _orderService.GetOrderByIdAsync(id);

			if (response != null && response.IsSuccess)
			{
				OrderDto? model = JsonConvert.DeserializeObject<OrderDto?>(Convert.ToString(response.Result));
                model.ShippingTaxTemp = model.ShippingTax.ToString();
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
		public async Task<IActionResult> OrderEdit(OrderDto model)
		{
            model.ShippingTax = Convert.ToDouble(model.ShippingTaxTemp);
            if (ModelState.IsValid)
			{
				ResponseDto? response = await _orderService.UpdateOrderAsync(model);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "Pedido atualizada com sucesso!";
					return RedirectToAction(nameof(OrderIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
				}
			}
            SeedStatusType();
            return View(model);
		}

		public async Task<IActionResult> OrderDelete(string id)
		{

			ResponseDto? response = await _orderService.GetOrderByIdAsync(id);

			if (response != null && response.IsSuccess)
			{
				OrderDto? model = JsonConvert.DeserializeObject<OrderDto?>(Convert.ToString(response.Result));
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
		public async Task<IActionResult> OrderDelete(OrderDto orderDto)
		{
			ResponseDto? response = await _orderService.DeleteOrderAsync(orderDto.Id);

			if (response != null && response.IsSuccess)
			{
				TempData["success"] = "Pedido excluida com sucesso!";
				return RedirectToAction(nameof(OrderIndex));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return NotFound(orderDto);
		}

		private void SeedStatusType()
		{
			var status = new List<SelectListItem>()
			{
				new SelectListItem{ Text=OrderStatus.Available, Value=OrderStatus.Available},
				new SelectListItem{ Text=OrderStatus.Accepted, Value=OrderStatus.Accepted},
				new SelectListItem{ Text=OrderStatus.Shipped, Value=OrderStatus.Shipped},
			};

			ViewBag.OrderStatus = status;
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
    }
}
