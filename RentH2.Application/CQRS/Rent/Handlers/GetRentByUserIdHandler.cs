using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Models;
using RentH2.Domain.Base;
using RentH2.Domain.Entities.Validators;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetRentByUserIdHandler : IRequestHandler<GetRentByUserIdQuery, ResponseModel>
    {
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetRentByUserIdHandler(IRentGateway rentGateway, IMapper mapper)
        {
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetRentByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<RentModel>(await _rentGateway.GetRentByUserIdAsync(request.userId, request.status));

            RentValidator.New()
                .When(result == null, Resources.RentNotFound)
                .ThrowExceptionIfExists();

            _responseModel.IsSuccess = true;
            _responseModel.Result = result;

            return _responseModel;
        }
    }
}
