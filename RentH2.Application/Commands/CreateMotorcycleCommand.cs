using MediatR;
using RentH2.Common.Models;

namespace RentH2.Application.Commands
{
    public record CreateMotorcycleCommand(MotorcycleModel MotorcycleModel) : IRequest<ResponseModel>;
}
