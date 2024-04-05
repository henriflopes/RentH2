using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class CreateRentHandler : IRequestHandler<CreateRentCommand, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ResponseModel _responseModel;

        public CreateRentHandler(IRentGateway rentGateway, IMapper mapper, IMediator mediator)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _mediator = mediator;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(CreateRentCommand request, CancellationToken cancellationToken)
        {
            //var rent = _mapper.Map<Rent>(request.RentModel);

            //var rentNumberPlate = await _mediator.Send(new GetRentByNumberPlateQuery(rent.NumberPlate));

            //RentValidator.New()
            //    .When(rentNumberPlate != null, Resources.RentExistsNumberPlate)
            //    .ThrowExceptionIfExists();

            //var result = await _rentGateway.CreateAsync(rent);

            //_responseModel.Result = _mapper.Map<RentModel>(result);

            //return _responseModel;

            return new ResponseModel();
        }
    }
}
