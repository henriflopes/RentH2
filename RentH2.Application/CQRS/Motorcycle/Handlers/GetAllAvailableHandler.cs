using MediatR;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Interface.Services;
using Newtonsoft.Json;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class GetAllAvailableHandler : IRequestHandler<GetAllAvailableQuery, ResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IRentService _rentService;
        private readonly ResponseModel _responseModel;

        public GetAllAvailableHandler(IMediator mediator, IRentService rentService)
        {
            _mediator = mediator;
            _rentService = rentService;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetAllAvailableQuery request, CancellationToken cancellationToken)
        {
            var unvailableResp = await _rentService.GetAllRentedByExpectedDateAsync(request.rentAgendaModel.StartDate, request.rentAgendaModel.EndDate);

            if (unvailableResp != null && unvailableResp.IsSuccess)
            {
                var unavailableAgendas = JsonConvert.DeserializeObject<List<RentModel>>(unvailableResp.Result.ToString());

                var availableResp = await _mediator.Send(new GetMotorcycleListByStatusQuery([RentStatus.Available]));

                if (availableResp != null && availableResp.IsSuccess)
                {
                    var availableMotorcycles = JsonConvert.DeserializeObject<List<MotorcycleModel>>(availableResp.Result.ToString());

                    _responseModel.Result = JsonConvert.SerializeObject(availableMotorcycles
                    .GroupJoin(
                        unavailableAgendas,
                        A => A.Id,
                        B => B.MotorcycleId,
                        (A, B) => new
                        {
                            ColumnsA = A,
                            ColumnsB = B.DefaultIfEmpty()
                        })
                    .SelectMany(joinResult => joinResult.ColumnsB.Where(B => B == null), (A, B) => A.ColumnsA)
                    .ToList());

                    _responseModel.IsSuccess = true;
                    return _responseModel;
                }
            }

            _responseModel.IsSuccess = false;
            _responseModel.Message = "Not found";

            return _responseModel;
        }
    }
}
