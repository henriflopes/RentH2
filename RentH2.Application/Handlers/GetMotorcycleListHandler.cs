using AutoMapper;
using MediatR;
using RentH2.Application.Queries;
using RentH2.Infra.Models;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class GetMotorcycleListHandler : IRequestHandler<GetMotorcycleListQuery, List<MotorcycleModel>>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public GetMotorcycleListHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public async Task<List<MotorcycleModel>> Handle(GetMotorcycleListQuery request, CancellationToken cancellationToken) 
            =>  _mapper.Map<List<MotorcycleModel>>(await _motorcycleGateway.GetAsync());
    }
}
