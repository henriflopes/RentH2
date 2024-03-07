using RentH2.Services.AuthAPI.Models.Dto;
using RentH2.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace RentH2.Services.AuthAPI.Controllers
{
	[Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		protected ResponseDto _response;

        public AuthAPIController(IAuthService authService, IConfiguration configuration, IMapper mapper)
		{
            _authService = authService;
            _configuration = configuration;
			_mapper = mapper;
			_response = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }

            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error encountered";
                return BadRequest(_response);
            }
            return Ok(_response);
        }

		[HttpGet("GetRiders")]
		public async Task<IActionResult> GetRiders()
		{
			var riders = await _authService.GetRiders();
			if (riders == null)
			{
				_response.IsSuccess = false;
				_response.Message = "Error encountered";
				return BadRequest(_response);
			}
			_response.Result = _mapper.Map<List<ApplicationUserDto>>(riders);
			return Ok(_response);
		}
	}
}
