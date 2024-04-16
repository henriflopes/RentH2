using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSMotorcycle.Queries
{
    public record GetMotorcycleListQuery() : IRequest<ResponseModel>;
}
