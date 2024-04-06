using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Common.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class GetPlanByIdHandler : IRequestHandler<GetPlanByIdQuery, ResponseModel>
    {
        private readonly IPlanGateway _planGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetPlanByIdHandler(IPlanGateway planGateway, IMapper mapper)
        {
            _planGateway = planGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<PlanModel>(await _planGateway.GetAsync(request.Id));

            MotorcycleValidator.New()
                .When(result == null, Resources.PlanNotFound)
                .ThrowExceptionIfExists();

            _responseModel.IsSuccess = true;
            _responseModel.Result = result;

            return _responseModel;
        }
    }
}
