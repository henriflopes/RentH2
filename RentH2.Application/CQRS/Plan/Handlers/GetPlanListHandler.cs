using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class GetPlanListHandler : IRequestHandler<GetPlanListQuery, ResponseModel>
    {
        private readonly IPlanGateway _planGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetPlanListHandler(IPlanGateway planGateway, IMapper mapper)
        {
            _planGateway = planGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetPlanListQuery request, CancellationToken cancellationToken)
        {
            _responseModel.Result = _mapper.Map<List<PlanModel>>(await _planGateway.GetAsync());
            return _responseModel;
        }
    }
}
