using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSRent.Queries
{
    public record GetRentByNumberPlateQuery(string numberPlate) : IRequest<RentModel>;
}
