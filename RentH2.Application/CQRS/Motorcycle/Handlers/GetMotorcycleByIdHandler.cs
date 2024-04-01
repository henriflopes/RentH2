﻿using AutoMapper;
using MediatR;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class GetMotorcycleByIdHandler : IRequestHandler<GetMotorcycleByIdQuery, ResponseModel>
    {
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public GetMotorcycleByIdHandler(IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(GetMotorcycleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<MotorcycleModel>(await _motorcycleGateway.GetAsync(request.Id));

            if (result != null)
            {
                if (!result.IsValid())
                {
                    _responseModel.Message = result.Erros.FirstOrDefault();
                    _responseModel.IsSuccess = false;
                    return _responseModel;
                }

                _responseModel.Result = result;

                return _responseModel;
            }

            _responseModel.Message = "Not Found";
            _responseModel.IsSuccess = false;
            return _responseModel;
        }
    }
}