using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class GetMotorcycleByNumberPlateHandler : IRequestHandler<GetMotorcycleByNumberPlateQuery, MotorcycleModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public GetMotorcycleByNumberPlateHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public async Task<MotorcycleModel> Handle(GetMotorcycleByNumberPlateQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<MotorcycleModel>(await _motorcycleGateway.GetByNumberPlateAsync(request.numberPlate));

            //MotorcycleValidator.New()
            //   .When(result == null, Resources.MotorcycleNumberPlateNotFound)
            //   .ThrowExceptionIfExists();

            return result;
        }
        
    }
}
