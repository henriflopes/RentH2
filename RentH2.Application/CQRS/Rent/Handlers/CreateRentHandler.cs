using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Domain.Models;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Utility;
using RentH2.Domain.Interface.Services;
using Newtonsoft.Json;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class CreateRentHandler : IRequestHandler<CreateRentCommand, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly IMotorcycleService _motorcycleService;
        private readonly ResponseModel _responseModel;

        public CreateRentHandler(IRentGateway rentGateway, IMapper mapper, IMotorcycleService motorcycleService)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _motorcycleService = motorcycleService;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {

            Rent rent = _mapper.Map<Rent>(request.RentModel);
            RentAgenda rentAgenda = _mapper.Map<RentAgenda>(rent);

            var resp = await _motorcycleService.GetAllAvailable(rentAgenda);

            if (resp != null && resp.IsSuccess)
            {
                var motorcycleModel = JsonConvert.DeserializeObject<List<MotorcycleModel>>(resp.Result.ToString()).FirstOrDefault();
                var motorcycle = _mapper.Map<Motorcycle>(motorcycleModel);
                motorcycle.UpdateStatus(RentStatus.Rented);
                await _motorcycleService.Put(_mapper.Map<MotorcycleModel>(motorcycle));
                
                rent.UpdateMotorcycleId(motorcycle.Id.ToString());
                var result = await _rentGateway.CreateAsync(rent);

                _responseModel.Result = JsonConvert.SerializeObject(_mapper.Map<RentModel>(result));

                return _responseModel;
            }

            _responseModel.IsSuccess = false;
            _responseModel.Message = "não há motos disponíveis para este período!";

            return _responseModel;
        }
    }
}
