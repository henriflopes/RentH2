using RentH2.Services.AuthAPI.Data;
using RentH2.Services.AuthAPI.Models;
using RentH2.Services.AuthAPI.Models.Dto;
using RentH2.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using RentH2.Services.AuthAPI.Utility;
using Npgsql;

namespace RentH2.Services.AuthAPI.Service
{
	public class AuthService : IAuthService
	{
		private readonly AppDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public AuthService(AppDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
		{
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		public async Task<bool> AssignRole(string email, string roleName)
		{
			var user = _context.ApplicationUsers.FirstOrDefault(q => q.Email.ToLower() == email.ToLower());

			if (user != null)
			{
				if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					//create role if it does not exist
					_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
				}

				await _userManager.AddToRoleAsync(user, roleName);
				return true;
			}
			return false;
		}

		public async Task<List<ApplicationUser>> GetRiders()
		{
			var riders = (await _userManager.GetUsersInRoleAsync(Roles.Rider)).ToList();

			return riders;
		}

		public async Task<LoginResponseDto> Login(LoginRequestDto request)
		{
			var user = _context.ApplicationUsers.FirstOrDefault(q => q.UserName.ToLower() == request.UserName.ToLower());

			bool isValid = await _userManager.CheckPasswordAsync(user, request.Password);

			if (user == null || !isValid)
			{
				return new LoginResponseDto()
				{
					User = null,
					Token = string.Empty
				};
			}

			//if user was found, Generate JWT Token
			var roles = await _userManager.GetRolesAsync(user);
			var token = _jwtTokenGenerator.GenerateToken(user, roles);

			UserDto userDto = new()
			{
				Email = user.Email,
				Id = user.Id,
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			LoginResponseDto loginResponseDto = new LoginResponseDto()
			{
				User = userDto,
				Token = token
			};

			return loginResponseDto;

		}

		public async Task<string> Register(RegistrationRequestDto request)
		{
			string result = "Erro Encontrado";

			ApplicationUser user = new()
			{
				UserName = request.Email,
				Email = request.Email,
				NormalizedEmail = request.Email.ToUpper(),
				Name = request.Name,
				PhoneNumber = request.PhoneNumber,
				DocumentId = request.DocumentId,
				DateBirth = request.DateBirth,
				DriverLicenseClass = request.DriverLicenseClass,
				DriverLicenseId = request.DriverLicenseId
			};

			try
			{
				var createResult = await _userManager.CreateAsync(user, request.Password);
				if (createResult.Succeeded)
				{
					await AssignRole(user.Email, request.Role);
					return string.Empty;
				}
				else
				{
					return createResult.Errors.FirstOrDefault().Description;
				}
			}
			catch (Exception ex)
			{
				if (ex.InnerException == null)
					return result;

				return HandleErrors.Message(ex.InnerException.Message);
			}
		}

		public async Task<string> UpdateUser(RegistrationRequestDto request, bool register = true)
		{
			try
			{
				var user = await _userManager.FindByEmailAsync(request.Email);

				if (user != null)
				{
					user.DriverLicenseImageLocalPath = request.DriverLicenseImgPath;
					user.DriverLicenseImageUrl = request.DriverLicenseImgUrl;

					var result = await _userManager.UpdateAsync(user);
					if (result.Succeeded)
					{
						return string.Empty;
					}
					else
					{
						return result.Errors.FirstOrDefault().Description;
					}
				}
			}
			catch (Exception ex)
			{

			}

			return "Erro Encontrado";
		}
	}
}
