using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class CreateMotorcycleHandler : IRequestHandler<CreateMotorcycleCommand>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public CreateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public Task Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_motorcycleGateway.CreateAsync(_mapper.Map<Motorcycle>(request.MotorcycleModel)));
        }
    }
}
