using AutoMapper;
using MediatR;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class DeleteRentHandler : IRequestHandler<DeleteRentCommand, ResponseModel>
    {
        private readonly IMediator _mediator;
        private readonly IRentGateway _rentGateway;
        private readonly IMapper _mapper;
        private readonly ResponseModel _responseModel;

        public DeleteRentHandler(IMediator mediator, IRentGateway rentGateway, IMapper mapper)
        {
            _mediator = mediator;
            _rentGateway = rentGateway;
            _mapper = mapper;
            _responseModel = new();
        }

        public async Task<ResponseModel> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            var rentModel = (RentModel)(await _mediator.Send(new GetRentByIdQuery(request.id))).Result;
            _responseModel.Result = rentModel;

            if (rentModel != null)
            {
                //var validator = await new DeleteRentValidator().ValidateAsync(rentModel, cancellationToken);
                //if (!validator.IsValid)
                //{
                //    rentModel.Erros = validator.Errors.Select(x => x.ErrorMessage).ToList();
                //    _responseModel.IsSuccess = false;
                //    _responseModel.Message = rentModel.Erros.FirstOrDefault();
                //    return _responseModel;
                //}

                if (rentModel != null)
                {
                    try
                    {
                        //var existsHist = await _ridersRentsService.GetOneByRentIdAsync(id);

                        //if (existsHist != null)
                        //{
                        //    rentModel.Status = RentStatus.Deleted;
                        //    await _mediator.Send(new UpdateRentCommand(rentModel));
                        //}
                        //else
                        //{
                        await _rentGateway.RemoveAsync(request.id);
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
