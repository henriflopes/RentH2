using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RentH2.Application.Commands;
using RentH2.Application.Queries;
using RentH2.Common.Models;
using RentH2.Services.MotorcycleAPI.Utility;

namespace RentH2.Services.MotorcycleAPI.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    //[Authorize(Roles = Roles.Administrator)]
    public class MotorcycleAPIController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ResponseModel _response;


        public MotorcycleAPIController(IMediator mediator)
        {
            _mediator = mediator;
            _response = new ResponseModel();
        }

        [HttpGet]
        public async Task<ResponseModel> Get()
        {
            try
            {
                _response.Result = await _mediator.Send(new GetMotorcycleListQuery());
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
                var result = await _mediator.Send(new GetMotorcycleByIdQuery(id));

                if (!result.IsValid())
                {
                    _response.Message = result.Erros.FirstOrDefault();
                    _response.IsSuccess = false;
                }

                _response.Result = result;
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
                _response.Result = await _mediator.Send(new GetMotorcycleListByStatusQuery(rentStatus));
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
                var result = await _mediator.Send(new CreateMotorcycleCommand(motorcycleModel));

                if (!result.IsValid())
                {
                    _response.Message = result.Erros.FirstOrDefault();
                    _response.IsSuccess = false;
                }

                _response.Result = result;
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
                var result = await _mediator.Send(new UpdateMotorcycleCommand(motorcycleModel));

                if (result != null)
                {
                    if (!result.IsValid()) 
                    {
                        _response.Message = result.Erros.FirstOrDefault();
                        _response.IsSuccess = false;
                    }

                    _response.Result = result;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = "Not Found";
                }
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
                await _mediator.Send(new DeleteMotorcycleCommand(id));
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
