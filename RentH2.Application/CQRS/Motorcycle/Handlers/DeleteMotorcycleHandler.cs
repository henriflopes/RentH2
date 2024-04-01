using AutoMapper;
using MediatR;
using RentH2.Application.CQRSMotorcycle.Commands;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Application.CQRSMotorcycle.Validators;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSMotorcycle.Handlers
{
    public class DeleteMotorcycleHandler : IRequestHandler<DeleteMotorcycleCommand, ResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public DeleteMotorcycleHandler(IMediator mediator, IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _mediator = mediator;
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            var motorcycleModel = (MotorcycleModel)(await _mediator.Send(new GetMotorcycleByIdQuery(request.id))).Result;
            _responseModel.Result = motorcycleModel;

            if (motorcycleModel != null)
            {
                var validator = await new DeleteMotorcycleValidator().ValidateAsync(motorcycleModel, cancellationToken);
                if (!validator.IsValid)
                {
                    motorcycleModel.Erros = validator.Errors.Select(x => x.ErrorMessage).ToList();
                    _responseModel.IsSuccess = false;
                    _responseModel.Message = motorcycleModel.Erros.FirstOrDefault();
                    return _responseModel;
                }

                if (motorcycleModel != null)
                {
                    try
                    {
                        //var existsHist = await _ridersRentsService.GetOneByMotorcycleIdAsync(id);

                        //if (existsHist != null)
                        //{
                        //    motorcycleModel.Status = RentStatus.Deleted;
                        //    await _mediator.Send(new UpdateMotorcycleCommand(motorcycleModel));
                        //}
                        //else
                        //{
                        await _motorcycleGateway.RemoveAsync(request.id);
                        //}

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                return _responseModel;
            }

            _responseModel.IsSuccess = false;
            _responseModel.Message = "Not Found";
            return _responseModel;
        }
    }
}
