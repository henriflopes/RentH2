using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSPlan.Queries
{
    public record GetPlanListQuery() : IRequest<ResponseModel>;
}
