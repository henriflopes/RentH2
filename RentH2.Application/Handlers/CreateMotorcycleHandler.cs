using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Application.Validators;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class CreateMotorcycleHandler : IRequestHandler<CreateMotorcycleCommand, MotorcycleModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper, IMediator mediator)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<MotorcycleModel> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var validator = await new NewMotorcycleValidator().ValidateAsync(request.MotorcycleModel, cancellationToken);
            if (!validator.IsValid)
            {
                request.MotorcycleModel.Erros = validator.Errors.Select( x => x.ErrorMessage).ToList();
                return request.MotorcycleModel;
            }

            var result = await _motorcycleGateway.GetByNumberPlateAsync(request.MotorcycleModel.NumberPlate);
            if (result != null)
            {
                request.MotorcycleModel.Erros = ["Esta placa já existe em nosso sistema!"];
                return request.MotorcycleModel;
            }

            return _mapper.Map<MotorcycleModel>(await _motorcycleGateway.CreateAsync(_mapper.Map<Motorcycle>(request.MotorcycleModel)));
        }
        
    }
}
