using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Commands;
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
            var plan = _mapper.Map<Plan>(request.planModel);
            var result = await _planGateway.CreateAsync(plan);

            _responseModel.IsSuccess = true;
            _responseModel.Result = result;

            return _responseModel;
        }
    }
}
