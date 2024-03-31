using MediatR;

namespace RentH2.Application.Commands
{
    public record DeleteMotorcycleCommand(string id) : IRequest;
}
