using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Common.Models;
using RentH2.Domain.Entities;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class UpdateMotorcycleHandler : IRequestHandler<UpdateMotorcycleCommand, ResponseModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public UpdateMotorcycleHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(UpdateMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<MotorcycleModel>(await _motorcycleGateway.UpdateAsync(_mapper.Map<Motorcycle>(request.MotorcycleModel)));

            if (result != null)
            {
                if (!result.IsValid())
                {
                    _responseModel.Message = result.Erros.FirstOrDefault();
                    _responseModel.IsSuccess = false;
                }

                _responseModel.Result = result;
            }
            else
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = "Not Found";
            }

            return _responseModel;
        }
    }
}