using MediatR;
using RentH2.Domain.Models;
using RentH2.Domain.Entities;

namespace RentH2.Application.CQRSRent.Queries
{
    public record GetAllRentedByExpectedDateQuery(DateTime startDate, DateTime endDate) : IRequest<ResponseModel>;
}
