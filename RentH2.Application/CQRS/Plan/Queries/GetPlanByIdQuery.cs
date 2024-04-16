using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSPlan.Queries
{
    public record GetPlanByIdQuery(string Id) : IRequest<ResponseModel>;
}
