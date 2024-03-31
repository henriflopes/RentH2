using AutoMapper;
using MediatR;
using RentH2.Application.Queries;
using RentH2.Common.Models;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class GetMotorcycleListHandler : IRequestHandler<GetMotorcycleListQuery, ResponseModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetMotorcycleListHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetMotorcycleListQuery request, CancellationToken cancellationToken)
        {
            _responseModel.Result = _mapper.Map<List<MotorcycleModel>>(await _motorcycleGateway.GetAsync());
            return _responseModel;
        }
    }
}
