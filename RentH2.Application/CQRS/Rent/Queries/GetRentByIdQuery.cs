using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSRent.Queries
{
    public record GetRentByIdQuery(string Id) : IRequest<ResponseModel>;
}
