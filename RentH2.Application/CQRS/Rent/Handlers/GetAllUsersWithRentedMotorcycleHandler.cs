using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRS.Rent.Handlers
{
    public class GetAllUsersWithRentedMotorcycleHandler : IRequestHandler<GetAllUsersWithRentedMotorcycleQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetAllUsersWithRentedMotorcycleHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetAllUsersWithRentedMotorcycleQuery request, CancellationToken cancellationToken)
        {
            //List<MotorcycleModel> motorcycles = await _motorcycleService.GetAllByStatusAsync([RentStatus.Rented]);
            //List<string?> motorcycleIds = motorcycles.Select(s => s.Id).ToList();
            //if (motorcycleIds == null)
            //{
            //    _responseModel.IsSuccess = false;
            //    _responseModel.Message = "Não existe motos com locação";

            //    return _responseModel;
            //}
            //else
            //{
            //    List<RidersRents> ridersRents = await _ridersRentsService.GetRentedMotorcyclesByIdAsync(motorcycleIds);
            //    List<string> rentsIds = ridersRents.Select(s => s.RentId).ToList();
            //    List<Rent> rents = await _rentService.GetAllRentByIdsAsync(rentsIds);

            //    List<Rent> userWithRentedMotorcycle = rents.Where(x => x.Status == RentStatus.Rented).ToList();
            //    _response.Result = _mapper.Map<RentModel>(userWithRentedMotorcycle);
            //}

            return _responseModel;

        }
    }
}
