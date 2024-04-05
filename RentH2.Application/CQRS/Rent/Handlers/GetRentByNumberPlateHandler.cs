using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Common.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetRentByNumberPlateHandler : IRequestHandler<GetRentByNumberPlateQuery, RentModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;

        public GetRentByNumberPlateHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
        }

        public async Task<RentModel> Handle(GetRentByNumberPlateQuery request, CancellationToken cancellationToken)
        {
            //var result = _mapper.Map<RentModel>(await _rentGateway.GetByNumberPlateAsync(request.numberPlate));

            //RentValidator.New()
            //   .When(result == null, Resources.RentNumberPlateNotFound)
            //   .ThrowExceptionIfExists();

            //return result;

            return new RentModel();
        }

    }
}
