using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentH2.Application.CQRSMotorcycle.Commands;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Common.Models;
using RentH2.Common.Utility;

namespace RentH2.Services.MotorcycleAPI.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    public class MotorcycleAPIController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ResponseModel _response;


        public MotorcycleAPIController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new();
        }

        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> Get()
        {
            try
            {
                _response = await _mediator.Send(new GetMotorcycleListQuery());
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
        [Authorize]
        public async Task<ResponseModel> Get(string id)
        {
            try
            {
                _response = await _mediator.Send(new GetMotorcycleByIdQuery(id));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost("GetAllByStatusAsync")]
        [Authorize]
        public async Task<ResponseModel> GetAllByStatusAsync([FromBody] List<string> rentStatus)
        {
            try
            {
                _response = await _mediator.Send(new GetMotorcycleListByStatusQuery(rentStatus));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }


        [HttpPost]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<ResponseModel> Post(MotorcycleModel motorcycleModel)
        {
            try
            {
                _response = await _mediator.Send(new CreateMotorcycleCommand(motorcycleModel));
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<ResponseModel> Put(MotorcycleModel motorcycleModel)
        {
            try
            {
                _response = await _mediator.Send(new UpdateMotorcycleCommand(motorcycleModel));
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
        [Authorize(Roles = Roles.Administrator)]
        public async Task<ResponseModel> Delete(string id)
        {
            try
            {
                _response = await _mediator.Send(new DeleteMotorcycleCommand(id));
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
