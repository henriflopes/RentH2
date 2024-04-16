using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSMotorcycle.Queries
{
    public record GetMotorcycleByIdQuery(string Id) : IRequest<ResponseModel>;
}
