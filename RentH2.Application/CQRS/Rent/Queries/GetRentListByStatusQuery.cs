using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSRent.Queries
{
    public record GetRentListByStatusQuery(List<string> status) : IRequest<ResponseModel>;
}
