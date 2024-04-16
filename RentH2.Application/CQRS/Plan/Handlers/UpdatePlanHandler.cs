using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class UpdatePlanHandler : IRequestHandler<UpdatePlanCommand, ResponseModel>
    {
        private readonly IPlanGateway _planGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public UpdatePlanHandler(IPlanGateway planGateway, IMapper mapper)
        {
            _planGateway = planGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _planGateway.GetAsync(request.planModel.Id);

            PlanValidator.New()
                .When(plan == null, Resources.PlanNotFound)
                .ThrowExceptionIfExists();

            plan.UpdateDescription(request.planModel.Description);
            plan.UpdateTotalDays(request.planModel.TotalDays);
            plan.UpdateStatus(request.planModel.Status);
            plan.UpdateTotalPrice(request.planModel.TotalPrice);
            plan.UpdateDailyPrice(request.planModel.DailyPrice);
            plan.UpdateFineAntecipated(request.planModel.FineAntecipated);
            plan.UpdateFineDelayed(request.planModel.FineDelayed);

            _responseModel.IsSuccess = true;
            _responseModel.Result = _mapper.Map<PlanModel>(await _planGateway.UpdateAsync(plan));

            return _responseModel;
        }
    }
}