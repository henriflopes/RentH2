using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetAllRentedByExpectedDateHandler : IRequestHandler<GetAllRentedByExpectedDateQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetAllRentedByExpectedDateHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetAllRentedByExpectedDateQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<RentModel>>(await _rentGateway.GetAllRentedByExpectedDateAsync(request.startDate, request.endDate));

            RentValidator.New()
                .When(result == null, Resources.RentNotFound)
                .ThrowExceptionIfExists();


            //List<RentAgenda> unavailableDates = [];
            //RentAgenda unavailableDate;

            //resultUnavailableDates.ForEach(x =>
            //{
            //    unavailableDate = new RentAgenda
            //    {
            //        StartDate = x.StartDate,
            //        EndDate = x.EndDate,
            //        TotalDaysInRow = (x.EndDate - x.StartDate).TotalDays,
            //        MotorcycleId = x.MotorcycleId
            //    };
            //    unavailableDate.Plan = x.Plan;

            //    unavailableDates.Add(unavailableDate);
            //});


            _responseModel.IsSuccess = true;
            _responseModel.Result = result;

            return _responseModel;
        }
    }
}
