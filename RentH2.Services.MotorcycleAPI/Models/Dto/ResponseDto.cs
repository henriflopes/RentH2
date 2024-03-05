namespace RentH2.Services.MotorcycleAPI.Models.Dto
{
	public class ResponseDto
	{
		public object? Result { get; set; }
		public bool IsSuccess { get; set; } = true;
		public string Message { get; set; } = string.Empty;
	}
}