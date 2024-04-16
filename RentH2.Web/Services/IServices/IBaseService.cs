using RentH2.Domain.Models;
using RentH2.Web.Models;

namespace RentH2.Web.Services.IServices
{
    public interface IBaseService
	{
		Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
		Task<ResponseModel?> SendAsync(RequestModel requestModel, bool withBearer = true);

    }
}
