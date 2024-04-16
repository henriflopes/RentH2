using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSRent.Queries
{
    public record GetRentByUserIdQuery(string userId, string status) : IRequest<ResponseModel>;
}
