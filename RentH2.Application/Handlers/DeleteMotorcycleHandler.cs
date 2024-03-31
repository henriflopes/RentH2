using AutoMapper;
using MediatR;
using RentH2.Application.Commands;
using RentH2.Application.Queries;
using RentH2.Application.Validators;
using RentH2.Common.Models;
using RentH2.Infra.Repositories.Interfaces;

namespace RentH2.Application.Handlers
{
    public class DeleteMotorcycleHandler : IRequestHandler<DeleteMotorcycleCommand>
    {
        private readonly IMediator _mediator;
        private readonly IMotorcycleGateway _motorcycleGateway;
        private readonly IMapper _mapper;

        public DeleteMotorcycleHandler(IMediator mediator,IMotorcycleGateway motorcycleGateway, IMapper mapper)
        {
            _mediator = mediator;
            _motorcycleGateway = motorcycleGateway;
            _mapper = mapper;
        }

        public async Task Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
        {
            //var validator = await new DeleteMotorcycleValidator().ValidateAsync(request.id);
            //if (!validator.IsValid)
            //{
            //    request.MotorcycleModel.Erros = validator.Errors.Select(x => x.ErrorMessage).ToList();
            //    return request.MotorcycleModel;
            //}


            MotorcycleModel motorcycleModel = await _mediator.Send(new GetMotorcycleByIdQuery(request.id));

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
        }
    }
}
