using AutoMapper;
using MediatR;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
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
            var result = _mapper.Map<PlanModel>(await _planGateway.UpdateAsync(_mapper.Map<Plan>(request.planModel)));

            if (result != null)
            {
                if (!result.IsValid())
                {
                    _responseModel.Message = result.Erros.FirstOrDefault();
                    _responseModel.IsSuccess = false;
                }

                _responseModel.Result = result;
            }
            else
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = "Not Found";
            }

            return _responseModel;
        }
    }
}