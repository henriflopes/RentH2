using AutoMapper;
using MediatR;
using RentH2.Application.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class GetMotorcycleByNumberPlateHandler : IRequestHandler<GetMotorcycleByNumberPlateQuery, MotorcycleModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public GetMotorcycleByNumberPlateHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }
        
        public async Task<MotorcycleModel> Handle(GetMotorcycleByNumberPlateQuery request, CancellationToken cancellationToken)
            => _mapper.Map<MotorcycleModel>(await _motorcycleGateway.GetAsync(request.numberPlate));
    }
}
