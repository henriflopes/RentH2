﻿using Microsoft.AspNetCore.Mvc;
using RentH2.Web.Models;

namespace RentH2.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto?> GetUserDetailsByUserId(string userName);
	}
}
