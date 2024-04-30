using AutoMapper;
using MediatR;
using RentH2.Application.CQRSMotorcycle.Commands;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class UpdateMotorcycleHandler : IRequestHandler<UpdateMotorcycleCommand, ResponseModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ResponseModel _responseModel;

        public UpdateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper, IMediator mediator)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _responseModel = new();
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycle = await _motorcycleGateway.GetAsync(request.MotorcycleModel.Id);
            MotorcycleValidator.New()
                .When(motorcycle == null, Resources.MotorcycleNotFound)
                .ThrowExceptionIfExists();

            if (request.MotorcycleModel.NumberPlate != motorcycle.NumberPlate)
            {
                var motorcycleNumberPlate = await _mediator.Send(new GetMotorcycleByNumberPlateQuery(request.MotorcycleModel.NumberPlate));
                MotorcycleValidator.New()
                    .When(motorcycleNumberPlate != null, Resources.MotorcycleExistsNumberPlate)
                    .ThrowExceptionIfExists();
            }

            motorcycle.UpdateYear(request.MotorcycleModel.Year);
            motorcycle.UpdateStatus(request.MotorcycleModel.Status);
            motorcycle.UpdateLocation(request.MotorcycleModel.Location);
            motorcycle.UpdateType(request.MotorcycleModel.Type);
            motorcycle.UpdateNumberPlate(request.MotorcycleModel.NumberPlate);

            _responseModel.Result = _mapper.Map<MotorcycleModel>(await _motorcycleGateway.UpdateAsync(motorcycle));
            _responseModel.IsSuccess = true;
            return _responseModel;
        }
    }
}