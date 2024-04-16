using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Entities;
using RentH2.Domain.Interface.Services;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;

namespace RentH2.Application.CQRSPlan.Handlers
{
    public class GetAvalaiblePlansHandler : IRequestHandler<GetAvalaiblePlansQuery, ResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMotorcycleService _motorcycleService;
        private readonly ResponseModel _responseModel;

        public GetAvalaiblePlansHandler(IMediator mediator, IMapper mapper, IMotorcycleService motorcycleService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _motorcycleService = motorcycleService;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetAvalaiblePlansQuery request, CancellationToken cancellationToken)
        {
            List<RentAgendaModel> RentAgendaModelResult = [];
            RentAgendaModel resultItem;

            var rentAgenda = _mapper.Map<RentAgenda>(request.rentAgendaModel);
            var respPlans = await _mediator.Send(new GetPlanListByStatusQuery([RentStatus.Available]));

            if (respPlans != null && respPlans.IsSuccess)
            {
                var plans = JsonConvert.DeserializeObject<List<PlanModel>>(respPlans.Result.ToString());

                if (plans.Count > 0)
                {
                    foreach (var plan in plans.OrderBy(o => o.TotalDays))
                    {
                        rentAgenda.EndDate = rentAgenda.StartDate.AddDays(plan.TotalDays);

                        var respMotorcycle = await _motorcycleService.GetAllAvailableAsync(request.rentAgendaModel);
                        if (respMotorcycle != null && respMotorcycle.IsSuccess)
                        {
                            var motorcycle = JsonConvert.DeserializeObject<List<MotorcycleModel>>(respMotorcycle.Result.ToString()).FirstOrDefault();

                            if (motorcycle == null)
                            {
                                plan.Status = RentStatus.Unavailable;
                            }

                            resultItem = new RentAgendaModel
                            {
                                StartDate = rentAgenda.StartDate,
                                EndDate = rentAgenda.EndDate,
                                TotalDaysInRow = plan.TotalDays,
                                MotorcycleId = motorcycle?.Id,
                                MotorcycleStatus = motorcycle?.Status,
                                Plan = plan
                            };

                            RentAgendaModelResult.Add(resultItem);
                        }
                    }

                    _responseModel.IsSuccess = true;
                    _responseModel.Result = JsonConvert.SerializeObject(RentAgendaModelResult);
                    return _responseModel;
                }
            }

            _responseModel.IsSuccess = false;
            _responseModel.Message = "Não há planos disponíveis para esta data.";
            return _responseModel;
        }
    }
}
