using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Application.CQRSPlan.Validators;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class CreatePlanHandler : IRequestHandler<CreatePlanCommand, ResponseModel>
    {
        private readonly IPlanGateway _planGateway;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ResponseModel _responseModel;

        public CreatePlanHandler(IPlanGateway planGateway, IMapper mapper, IMediator mediator)
        {
            _planGateway = planGateway;
            _mapper = mapper;
            _mediator = mediator;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var validator = await new NewPlanValidator().ValidateAsync(request.planModel, cancellationToken);
            if (validator.IsValid)
            {
                 _responseModel.Result = _mapper.Map<PlanModel>(await _planGateway.CreateAsync(_mapper.Map<Plan>(request.planModel)));

                return _responseModel;
            }

            request.planModel.Erros = validator.Errors.Select(x => x.ErrorMessage).ToList();

            _responseModel.IsSuccess = false;
            _responseModel.Message = request.planModel.Erros.FirstOrDefault();
            _responseModel.Result = request.planModel;

            return _responseModel;
        }
    }
}
