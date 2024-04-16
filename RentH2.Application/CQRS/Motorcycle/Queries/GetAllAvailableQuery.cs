using MediatR;
using RentH2.Domain.Entities;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSMotorcycle.Queries
{
    public record GetAllAvailableQuery(RentAgenda rentAgenda) : IRequest<ResponseModel>;
}
