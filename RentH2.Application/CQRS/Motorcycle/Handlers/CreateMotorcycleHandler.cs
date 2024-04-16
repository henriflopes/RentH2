using AutoMapper;
using MediatR;
using RentH2.Application.CQRSMotorcycle.Commands;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class CreateMotorcycleHandler : IRequestHandler<CreateMotorcycleCommand, ResponseModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ResponseModel _responseModel;

        public CreateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper, IMediator mediator)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _mediator = mediator;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycle = _mapper.Map<Motorcycle>(request.MotorcycleModel);

            var motorcycleNumberPlate = await _mediator.Send(new GetMotorcycleByNumberPlateQuery(motorcycle.NumberPlate));

            MotorcycleValidator.New()
                .When(motorcycleNumberPlate != null, Resources.MotorcycleExistsNumberPlate)
                .ThrowExceptionIfExists();

            var result = await _motorcycleGateway.CreateAsync(motorcycle);

            _responseModel.IsSuccess = true;
            _responseModel.Result = _mapper.Map<MotorcycleModel>(result);

            return _responseModel;
        }
    }
}
