using MediatR;
using RentH2.Infra.Models;

namespace RentH2.Application.Commands
{
    public record UpdateMotorcycleCommand(MotorcycleModel MotorcycleModel) : IRequest;
}
