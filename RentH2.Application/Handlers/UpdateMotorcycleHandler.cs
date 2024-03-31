using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class UpdateMotorcycleHandler : IRequestHandler<UpdateMotorcycleCommand, MotorcycleModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public UpdateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public async Task<MotorcycleModel> Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
            => _mapper.Map<MotorcycleModel>(await _motorcycleGateway.UpdateAsync(_mapper.Map<Motorcycle>(request.MotorcycleModel)));

    }
}