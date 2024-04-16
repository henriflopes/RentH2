using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSMotorcycle.Commands
{
    public record UpdateMotorcycleCommand(MotorcycleModel MotorcycleModel) : IRequest<ResponseModel>;
}
