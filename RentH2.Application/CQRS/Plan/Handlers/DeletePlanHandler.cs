using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Application.CQRSPlan.Validators;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class DeletePlanHandler : IRequestHandler<DeletePlanCommand, ResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IPlanGateway _planGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public DeletePlanHandler(IMediator mediator, IPlanGateway planGateway, IMapper mapper)
        {
            _mediator = mediator;
            _planGateway = planGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            var planModel = (PlanModel)(await _mediator.Send(new GetPlanByIdQuery(request.id))).Result;
            _responseModel.Result = planModel;

            if (planModel != null)
            {
                var validator = await new DeletePlanValidator().ValidateAsync(planModel, cancellationToken);
                if (!validator.IsValid)
                {
                    planModel.Erros = validator.Errors.Select(x => x.ErrorMessage).ToList();
                    _responseModel.IsSuccess = false;
                    _responseModel.Message = planModel.Erros.FirstOrDefault();
                    return _responseModel;
                }

                if (planModel != null)
                {
                    try
                    {
                        //var existsHist = await _ridersRentsService.GetOneByPlanIdAsync(id);

                        //if (existsHist != null)
                        //{
                        //    planModel.Status = RentStatus.Deleted;
                        //    await _mediator.Send(new UpdatePlanCommand(planModel));
                        //}
                        //else
                        //{
                        await _planGateway.RemoveAsync(request.id);
                        //}

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                return _responseModel;
            }

            _responseModel.IsSuccess = false;
            _responseModel.Message = "Not Found";
            return _responseModel;
        }
    }
}
