using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class DeleteMotorcycleHandler : IRequestHandler<DeleteMotorcycleCommand>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public DeleteMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public Task Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_motorcycleGateway.RemoveAsync(request.id));
        }
    }
}
