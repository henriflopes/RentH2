using MediatR;
using RentH2.Infra.Models;

namespace RentH2.Application.Queries
{
    public record GetMotorcycleListByStatusQuery(List<string> status) : IRequest<List<MotorcycleModel>>;
}
