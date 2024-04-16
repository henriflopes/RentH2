using MediatR;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Interface.Services;
using RentH2.Domain.Models;

namespace RentH2.Application.CQRSRent.Handlers
{
    public class GetAvalaiblePlansForRentHandler : IRequestHandler<GetAvalaiblePlansForRentQuery, ResponseModel>
    {
        private readonly IPlanService _planService;

        public GetAvalaiblePlansForRentHandler(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<ResponseModel> Handle(GetAvalaiblePlansForRentQuery request, CancellationToken cancellationToken)
        {
            return await _planService.GetAvalaiblePlansAsync(request.rentAgendaModel);
        }
    }
}
