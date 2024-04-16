using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Interface.Services;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetAllUsersWithRentedMotorcycleHandler : IRequestHandler<GetAllUsersWithRentedMotorcycleQuery, ResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IMotorcycleService _motorcycleService;
        private readonly IMediator _mediator;
        private readonly ResponseModel _responseModel;

        public GetAllUsersWithRentedMotorcycleHandler(IMediator mediator, IMapper mapper, IMotorcycleService motorcycleService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _motorcycleService = motorcycleService;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetAllUsersWithRentedMotorcycleQuery request, CancellationToken cancellationToken)
        {

            var resp = await _motorcycleService.GetAllByStatusAsync([RentStatus.Rented]);
            if (resp != null && resp.IsSuccess)
            {
                var motorcyclesModel = JsonConvert.DeserializeObject<List<MotorcycleModel>>(resp.Result.ToString());
                if (motorcyclesModel.Count > 0)
                {
                    List<string?> motorcycleIds = motorcyclesModel.Select(s => s.Id).ToList();

                    var respRentedMotorcycles = await _mediator.Send(new GetRentedMotorcyclesByIdQuery(motorcycleIds));

                    if (respRentedMotorcycles != null && respRentedMotorcycles.IsSuccess)
                    {
                        var rentedMotorcyclesModel = JsonConvert.DeserializeObject<List<RentModel>>(respRentedMotorcycles.Result.ToString());
                        List<string> rentsIds = rentedMotorcyclesModel.Select(s => s.Id).ToList();

                        var respRentsByIds = await _mediator.Send(new GetRentsByIdsQuery(rentsIds));
                        if (respRentsByIds != null && respRentsByIds.IsSuccess)
                        {
                            var rentsModel = JsonConvert.DeserializeObject<List<RentModel>>(respRentsByIds.Result.ToString());
                            List<RentModel> userWithRentedMotorcycle = rentsModel.Where(x => x.Status == RentStatus.Rented).ToList();

                            _responseModel.Result = JsonConvert.SerializeObject(_mapper.Map<RentModel>(userWithRentedMotorcycle));
                            _responseModel.IsSuccess = true;

                            return _responseModel;
                        }
                    }
                }
            }

            _responseModel.IsSuccess = false;
            _responseModel.Message = "Não existe motos com locação";

            return _responseModel;
        }
    }
}
