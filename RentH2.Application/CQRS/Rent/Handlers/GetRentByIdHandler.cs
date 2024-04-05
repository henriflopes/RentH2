using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetRentByIdHandler : IRequestHandler<GetRentByIdQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetRentByIdHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
        {
            //var result = _mapper.Map<RentModel>(await _rentGateway.GetAsync(request.Id));

            //RentValidator.New()
            //    .When(result == null, Resources.RentNotFound)
            //    .ThrowExceptionIfExists();

            //_responseModel.Result = result;

            //return _responseModel;

            return new ResponseModel();
        }
    }
}
