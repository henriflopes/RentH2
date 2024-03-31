using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.Queries
{
    public record GetMotorcycleListByStatusQuery(List<string> status) : IRequest<List<MotorcycleModel>>;
}
