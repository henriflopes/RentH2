using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetRentListHandler : IRequestHandler<GetRentListQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetRentListHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetRentListQuery request, CancellationToken cancellationToken)
        {
            _responseModel.Result = _mapper.Map<List<RentModel>>(await _rentGateway.GetAsync());
            return _responseModel;
        }
    }
}
