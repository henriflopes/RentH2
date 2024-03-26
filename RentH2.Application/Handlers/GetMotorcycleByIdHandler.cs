using AutoMapper;
using MediatR;
using RentH2.Application.Queries;
using RentH2.Infra.Models;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class GetMotorcycleByIdHandler : IRequestHandler<GetMotorcycleByIdQuery, MotorcycleModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public GetMotorcycleByIdHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public async Task<MotorcycleModel> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
            => _mapper.Map<MotorcycleModel>(await _motorcycleGateway.GetAsync(request.Id));
    }
}
