using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSRent.Commands
{
    public record UpdateRentCommand(RentModel RentModel) : IRequest<ResponseModel>;
}
