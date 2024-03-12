using RentH2.Web.Models;
using RentH2.Web.Services.IServices;
using RentH2.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RentH2.Web.Controllers
{
	public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();


            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            ResponseDto responseDto = await _authService.LoginAsync(model);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto =
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SignInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
			SeedDropDownList();
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(RegistrationRequestDto model)
		{
			var result = CreateUserFunc(ref model);

			if (result != null && result.IsSuccess)
			{
				TempData["success"] = $"Cadastro de {model.Role} feito com sucesso!";
				return RedirectToAction(nameof(Login));
			}
			else
			{
				TempData["error"] = result?.Message;
			}

			SeedDropDownList();
			return View(model);
		}

		[HttpGet]
        public IActionResult RegisterUser()
        {
            SeedDropDownList();
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> RegisterUser(RegistrationRequestDto model)
		{
			var result = CreateUserFunc(ref model);

			if (result != null && result.IsSuccess)
			{
				TempData["success"] = "Parábens motociclista seu cadastro foi concluido!";
				return RedirectToAction(nameof(Login));
			}
            else
            {
				TempData["error"] = result?.Message;
			}

			SeedDropDownList();
			return View(model);
		}
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }

        private async Task SignInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(q => q.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        }

		private void SeedDropDownList()
		{
			var roles = new List<SelectListItem>()
			{
				new() { Text=Roles.Administrator, Value=Roles.Administrator},
				new() { Text=Roles.Rider, Value=Roles.Rider}
			};

			var driverClasses = new List<SelectListItem>()
			{
				new() { Text=$"Classe {DriverLicenseClasses.ClassA}", Value=DriverLicenseClasses.ClassA},
				new() { Text=$"Classe {DriverLicenseClasses.ClassB}", Value=DriverLicenseClasses.ClassB},
				new() { Text=$"Classe {DriverLicenseClasses.ClassAB}", Value=DriverLicenseClasses.ClassAB}
			};

			ViewBag.Classes = driverClasses;
			ViewBag.Roles = roles;
		}

		private ResponseDto CreateUserFunc(ref RegistrationRequestDto model)
		{
			if (string.IsNullOrEmpty(model.Role))
			{
				model.Role = Roles.Rider;
			}

			ResponseDto? result = _authService.RegisterAsync(model).GetAwaiter().GetResult();
			ResponseDto? resultAssignRole = new();

			if (result != null && result.IsSuccess)
			{
				resultAssignRole = _authService.AssignRoleAsync(model).GetAwaiter().GetResult();
			}

			return resultAssignRole;
		}
	}
}
