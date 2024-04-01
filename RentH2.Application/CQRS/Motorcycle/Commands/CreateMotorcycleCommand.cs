using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSMotorcycle.Commands
{
    public record CreateMotorcycleCommand(MotorcycleModel MotorcycleModel) : IRequest<ResponseModel>;
}
