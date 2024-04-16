using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Interface.Services;
using RentH2.Domain.Utility;
using Newtonsoft.Json;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetAllRentedByExpectedDateHandler : IRequestHandler<GetAllRentedByExpectedDateQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly IMotorcycleService _motorcycleService;
        private readonly ResponseModel _responseModel;

        public GetAllRentedByExpectedDateHandler(IRentGateway rentGateway, IMapper mapper, IMotorcycleService motorcycleService)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _motorcycleService = motorcycleService;
            _responseModel = new();
        }

        public async Task<ResponseModel?> Handle(GetAllRentedByExpectedDateQuery request, CancellationToken cancellationToken)
        {
            List<RentModel> result =
            [
                .. _mapper.Map<List<RentModel>>(await _rentGateway.GetAllRentedByExpectedDateAsync(request.startDate, request.endDate)),
            ];

            _responseModel.IsSuccess = true;
            _responseModel.Result = result;

            return _responseModel;
        }
    }
}
