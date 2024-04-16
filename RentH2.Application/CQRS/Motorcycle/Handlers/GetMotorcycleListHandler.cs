using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Models;
using RentH2.Infrastructure.Repositories.Interfaces;
using Newtonsoft.Json;

namespace RentH2.Application.CQRSMotorcycle.Handlers
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
            _responseModel.Result = JsonConvert.SerializeObject(_mapper.Map<List<MotorcycleModel>>(await _motorcycleGateway.GetAsync()));
            _responseModel.IsSuccess = true;
            return _responseModel;
        }
    }
}
