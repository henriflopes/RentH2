using Refit;
using RentH2.Domain.Entities;
using RentH2.Domain.Models;

namespace RentH2.Domain.Interface.Services
{
	public interface IMotorcycleService
	{
		[Post("/api/motorcycle")]
		Task<ResponseModel> GetAllByStatusAsync(List<string> rentStatus);

		[Put("/api/motorcycle")]
		Task<ResponseModel> Put(MotorcycleModel motorcycleModel);

        [Post("/api/motorcycle/GetAllAvailableAsync")]
        Task<ResponseModel> GetAllAvailableAsync(RentAgendaModel rentAgendaModel);
    }
}
