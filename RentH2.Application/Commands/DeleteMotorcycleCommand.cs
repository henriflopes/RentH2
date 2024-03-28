using MediatR;
using RentH2.Infra.Models;

namespace RentH2.Application.Commands
{
    public record DeleteMotorcycleCommand(string id) : IRequest;
}
