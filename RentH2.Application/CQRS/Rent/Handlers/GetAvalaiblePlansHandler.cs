using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetAvalaiblePlansHandler : IRequestHandler<GetAvalaiblePlansQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetAvalaiblePlansHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public Task<ResponseModel> Handle(GetAvalaiblePlansQuery request, CancellationToken cancellationToken)
        {
            //List<RentAgendaModel> RentAgendaDtoResult = [];
            //RentAgendaModel resultItem;

            //var rentAgenda = _mapper.Map<RentAgenda>(rentAgendaDto);
            //var plans = await _planService.GetAllByStatusAsync([RentStatus.Available]);

            //foreach (var plan in plans.OrderBy(o => o.TotalDays))
            //{
            //    rentAgenda.EndDate = rentAgenda.StartDate.AddDays(plan.TotalDays);
            //    var motorcycle = await _motorcycleService.GetOneAvailable(rentAgenda);
            //    if (motorcycle == null)
            //    {
            //        plan.Status = RentStatus.Unavailable;
            //    }

            //    resultItem = new RentAgendaModel
            //    {
            //        StartDate = rentAgenda.StartDate,
            //        EndDate = rentAgenda.EndDate,
            //        TotalDaysInRow = plan.TotalDays,
            //        MotorcycleId = motorcycle?.Id,
            //        MotorcycleStatus = motorcycle?.Status,
            //        Plan = plan
            //    };

            //    RentAgendaDtoResult.Add(resultItem);
            //}

            //_response.Result = RentAgendaDtoResult;

            throw new NotImplementedException();
        }
    }
}
