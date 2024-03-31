using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.Commands
{
    public record UpdateMotorcycleCommand(MotorcycleModel MotorcycleModel) : IRequest<MotorcycleModel>;
}
