using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Common.Models;

namespace RentH2.Services.RentAPI.Controllers
{
    [Route("api/rent")]
    [ApiController]
    [Authorize]
    public class RentAPIController : ControllerBase
    {
        private ResponseModel _responseModel;
        private readonly IMediator _mediator;

        public RentAPIController(IMediator mediator)
        {
            _responseModel = new ResponseModel();
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllRent()
        {
            try
            {
                _responseModel = await _mediator.Send(new GetRentListQuery());
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpPost("GetAllRentedByExpectedDateAsync")]
        public async Task<ResponseModel> GetAllRentedByExpectedDateAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                _responseModel = await _mediator.Send(new GetAllRentedByExpectedDateQuery(startDate, endDate));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpPost("GetAvalaiblePlans")]
        public async Task<ResponseModel> GetAvalaiblePlans([FromBody] RentAgendaModel rentAgendaModel)
        {
            try
            {
                _responseModel = await _mediator.Send(new GetAvalaiblePlansQuery(rentAgendaModel));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpPost("RentAsync")]
        public async Task<ResponseModel> RentAsync([FromBody] RentModel rentModel)
        {
            try
            {
                _responseModel = await _mediator.Send(new CreateRentCommand(rentModel));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpGet("GetRentByUserIdAsync")]
        public async Task<ResponseModel> GetRentByUserIdAsync(string userId, string status)
        {
            try
            {
                _responseModel = await _mediator.Send(new GetRentByUserIdQuery(userId, status));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseModel> Get(string id)
        {
            try
            {
                _responseModel = await _mediator.Send(new GetRentByIdQuery(id));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpPut]
        public async Task<ResponseModel> Put(RentModel rentModel)
        {
            try
            {
                _responseModel = await _mediator.Send(new UpdateRentCommand(rentModel));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseModel> Delete(string id)
        {
            try
            {
                _responseModel = await _mediator.Send(new DeleteRentCommand(id));
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

        [HttpGet("GetAllUsersWithRentedMotorcycleAsync")]
        public async Task<ResponseModel> GetAllUsersWithRentedMotorcycleAsync()
        {
            try
            {
                _responseModel = await _mediator.Send(new GetAllUsersWithRentedMotorcycleQuery());
            }
            catch (Exception ex)
            {
                _responseModel.IsSuccess = false;
                _responseModel.Message = ex.Message;
            }

            return _responseModel;
        }

    }
}
