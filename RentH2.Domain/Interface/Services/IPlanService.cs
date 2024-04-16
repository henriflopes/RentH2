using Refit;
using RentH2.Domain.Models;

namespace RentH2.Domain.Interface.Services
{
    public interface IPlanService
    {
        [Post("/api/plan/GetAvalaiblePlansAsync")]
        Task<ResponseModel> GetAvalaiblePlansAsync(RentAgendaModel rentAgendaModel);
    }
}