using MediatR;
using RentH2.Infra.Models;

namespace RentH2.Application.Queries
{
    public record GetMotorcycleListQuery() : IRequest<List<MotorcycleModel>>;
}
