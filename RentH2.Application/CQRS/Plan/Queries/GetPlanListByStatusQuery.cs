using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSPlan.Queries
{
    public record GetPlanListByStatusQuery(List<string> status) : IRequest<ResponseModel>;
}
