using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetRentListByStatusHandler : IRequestHandler<GetRentListByStatusQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetRentListByStatusHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetRentListByStatusQuery request, CancellationToken cancellationToken)
        {
            //_responseModel.Result = _mapper.Map<List<RentModel>>(await _rentGateway.GetAllByStatusAsync(request.status));
            //return _responseModel;

            return new ResponseModel();
        }
    }
}
