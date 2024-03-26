using MediatR;
using RentH2.Infra.Models;

namespace RentH2.Application.Commands
{
    public record CreateMotorcycleCommand(MotorcycleModel MotorcycleModel) : IRequest;
}
