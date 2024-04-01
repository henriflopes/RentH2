using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.CQRSMotorcycle.Commands
{
    public record DeleteMotorcycleCommand(string id) : IRequest<ResponseModel>;
}
