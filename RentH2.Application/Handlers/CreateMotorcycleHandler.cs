using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Application.Queries;
using RentH2.Application.Validators;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.Handlers
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
            var validator = await new NewMotorcycleValidator().ValidateAsync(request.MotorcycleModel, cancellationToken);
            if (validator.IsValid)
            {
                var result = await _mediator.Send(new GetMotorcycleByNumberPlateQuery(request.MotorcycleModel.NumberPlate));
                if (result != null)
                {
                    _responseModel.IsSuccess = false;
                    _responseModel.Message = "Esta placa já existe em nosso sistema!";

                    return _responseModel;
                }

                _responseModel.Result = _mapper.Map<MotorcycleModel>(await _motorcycleGateway.CreateAsync(_mapper.Map<Motorcycle>(request.MotorcycleModel)));

                return _responseModel;
            }

            request.MotorcycleModel.Erros = validator.Errors.Select(x => x.ErrorMessage).ToList();

            _responseModel.IsSuccess = false;
            _responseModel.Message = request.MotorcycleModel.Erros.FirstOrDefault();
            _responseModel.Result = request.MotorcycleModel;

            return _responseModel;
        }
    }
}
