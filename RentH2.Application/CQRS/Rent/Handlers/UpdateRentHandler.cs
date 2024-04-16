using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Models;
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
            var rent = await _rentGateway.GetAsync(request.RentModel.Id);
            RentValidator.New()
               .When(rent == null, Resources.RentNotFound)
               .ThrowExceptionIfExists();

            rent.UpdateStatus(request.RentModel.Status);
            rent.UpdateStartDate(request.RentModel.StartDate);
            rent.UpdateEndDate(request.RentModel.EndDate);
            rent.UpdateEndDateExpected(request.RentModel.EndDateExpected);
            rent.UpdateMotorcycleId(request.RentModel.MotorcycleId);
            rent.UpdateUserId(request.RentModel.UserId);
            rent.UpdateTotal(request.RentModel.Total);
            rent.UpdateTotalExpected(request.RentModel.TotalExpected);
            rent.UpdatePlan(request.RentModel.Plan);

            _responseModel.Result = _mapper.Map<RentModel>(await _rentGateway.UpdateAsync(rent));

            return _responseModel;
        }
    }
}