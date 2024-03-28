using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class UpdateMotorcycleHandler : IRequestHandler<UpdateMotorcycleCommand>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public UpdateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public Task Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_motorcycleGateway.UpdateAsync(_mapper.Map<Motorcycle>(request.MotorcycleModel)));
        }
    }
}
