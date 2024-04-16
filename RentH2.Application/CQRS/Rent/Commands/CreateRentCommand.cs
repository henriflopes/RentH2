using MediatR;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSRent.Commands
{
    public record CreateRentCommand(RentModel RentModel) : IRequest<ResponseModel>;
}
