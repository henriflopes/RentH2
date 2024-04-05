using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class UpdateRentHandler : IRequestHandler<UpdateRentCommand, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ResponseModel _responseModel;

        public UpdateRentHandler(IRentGateway rentGateway, IMapper mapper, IMediator mediator)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
        {
            //var rent = await _rentGateway.GetAsync(request.RentModel.Id);
            //RentValidator.New()
            //   .When(rent == null, Resources.RentNotFound)
            //   .ThrowExceptionIfExists();

            //var rentNumberPlate = await _mediator.Send(new GetRentByNumberPlateQuery(rent.NumberPlate));
            //RentValidator.New()
            //    .When(rentNumberPlate != null, Resources.RentExistsNumberPlate)
            //    .ThrowExceptionIfExists();

            //rent.UpdateYear(request.RentModel.Year);
            //rent.UpdateStatus(request.RentModel.Status);
            //rent.UpdateLocation(request.RentModel.Location);
            //rent.UpdateType(request.RentModel.Type);
            //rent.UpdateNumberPlate(request.RentModel.NumberPlate);

            //_responseModel.Result = _mapper.Map<RentModel>(await _rentGateway.UpdateAsync(rent));

            //return _responseModel;

            return new ResponseModel();
        }
    }
}