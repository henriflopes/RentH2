using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSPlan.Commands
{
    public record UpdatePlanCommand(PlanModel planModel) : IRequest<ResponseModel>;
}
