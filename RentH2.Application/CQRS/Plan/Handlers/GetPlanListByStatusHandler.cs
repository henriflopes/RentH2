using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class GetPlanListByStatusHandler : IRequestHandler<GetPlanListByStatusQuery, ResponseModel>
    {
        private readonly IPlanGateway _planGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetPlanListByStatusHandler(IPlanGateway planGateway, IMapper mapper)
        {
            _planGateway = planGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetPlanListByStatusQuery request, CancellationToken cancellationToken)
        {
            _responseModel.Result = _mapper.Map<List<PlanModel>>(await _planGateway.GetAllByStatusAsync(request.status));
            return _responseModel;
        }
    }
}
