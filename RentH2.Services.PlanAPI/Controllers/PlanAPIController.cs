using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Models;

namespace RentH2.Services.PlanAPI.Controllers
{
    [Route("api/plan")]
	[ApiController]
	//[Authorize]
	public class PlanAPIController : ControllerBase
	{
		private ResponseModel _response;
        private readonly IMediator _mediator;

        public PlanAPIController(IMediator mediator)
		{
			_response = new ResponseModel();
            _mediator = mediator;
        }


		[HttpGet]
		public async Task<ResponseModel> Get()
		{
			try
			{
                _response = await _mediator.Send(new GetPlanListQuery());
            }
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
		}

		[HttpPost("GetAllByStatusAsync")]
		public async Task<ResponseModel> GetAllByStatusAsync([FromBody] List<string> rentStatus)
		{
			try
			{
                _response = await _mediator.Send(new GetPlanListByStatusQuery(rentStatus));
            }
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
		}

        [HttpPost("GetAvalaiblePlansAsync")]
        public async Task<ResponseModel> GetAvalaiblePlansAsync([FromBody] RentAgendaModel rentAgendaModel)
        {
            try
            {
                _response = await _mediator.Send(new GetAvalaiblePlansQuery(rentAgendaModel));
            }
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
		[Route("{id}")]
		public async Task<ResponseModel> Get(string id)
		{
			try
			{
                _response = await _mediator.Send(new GetPlanByIdQuery(id));
			}
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
		}


		[HttpPost]
		public async Task<ResponseModel> Post(PlanModel planModel)
		{
			try
			{
                _response = await _mediator.Send(new CreatePlanCommand(planModel));

            }
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
		}

		[HttpPut]
		public async Task<ResponseModel> Put(PlanModel planModel)
		{
			try
			{
                _response = await _mediator.Send(new UpdatePlanCommand(planModel));
            }
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ResponseModel> Delete(string id)
		{
			try
			{
                _response = await _mediator.Send(new DeletePlanCommand(id));
            }
            catch (ExceptionDomain exDomain)
            {
                _response.IsSuccess = false;
                _response.Message = exDomain.ErrorMessages.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
		}
	}
}
