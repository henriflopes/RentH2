using MediatR;
using RentH2.Common.Models;
using RentH2.Domain.Entities;

namespace RentH2.Application.CQRSRent.Queries
{
    public record GetAllRentedByExpectedDateQuery(RentAgenda rentAgenda) : IRequest<ResponseModel>;
}
