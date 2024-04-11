using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class CreateRentHandler : IRequestHandler<CreateRentCommand, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public CreateRentHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {

            //Rent rent = _mapper.Map<Rent>(rentDto);

            //RentAgenda rentAgenda = _mapper.Map<RentAgenda>(rent);

            //var motorcycle = await _motorcycleService.GetOneAvailable(rentAgenda);
            //if (motorcycle == null)
            //{
            //    _response.IsSuccess = false;
            //    _response.Message = "Não há motos disponíveis para este período!";

            //    return _response;
            //}

            //var motorcycleDto = _mapper.Map<Motorcycle>(motorcycle);
            //motorcycleDto.Status = RentStatus.Rented;
            //await _motorcycleService.UpdateAsync(motorcycleDto);
            //rent.Motorcycle = motorcycleDto;

            //var result = await _rentService.CreateAsync(rent);

            //RidersRents ridersRents = new RidersRents
            //{
            //    RentId = result.Id,
            //    MotorcycleId = rent.Motorcycle.Id,
            //    PlanId = rent.Plan.Id,
            //    UserId = rent.User.Id,
            //    TimeStamp = DateTime.UtcNow
            //};

            //await _ridersRentsService.CreateAsync(ridersRents);

            //_response.Result = _mapper.Map<RentDto>(rent);


            var rent = _mapper.Map<Rent>(request.RentModel);

            var result = await _rentGateway.CreateAsync(rent);

            _responseModel.Result = _mapper.Map<RentModel>(result);

            return _responseModel;
        }
    }
}
