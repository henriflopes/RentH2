using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;
using Newtonsoft.Json;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class GetMotorcycleByIdHandler : IRequestHandler<GetMotorcycleByIdQuery, ResponseModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetMotorcycleByIdHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = JsonConvert.SerializeObject(_mapper.Map<MotorcycleModel>(await _motorcycleGateway.GetAsync(request.Id)));

            MotorcycleValidator.New()
                .When(result == null, Resources.MotorcycleNotFound)
                .ThrowExceptionIfExists();

            _responseModel.IsSuccess = true;
            _responseModel.Result = result;

            return _responseModel;
        }
    }
}
