using MediatR;
using RentH2.Infra.Models;

namespace RentH2.Application.Queries
{
    public record GetMotorcycleByIdQuery(string Id) : IRequest<MotorcycleModel>;
}
