using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RentH2.Application.Commands;
using RentH2.Application.Queries;
using RentH2.Common.Models;

namespace RentH2.Services.MotorcycleAPI.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    //[Authorize(Roles = Roles.Administrator)]
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
