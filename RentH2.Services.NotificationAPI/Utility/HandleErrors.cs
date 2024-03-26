namespace RentH2.Services.NotificationAPI.Utility
{
	public static class HandleErrors
	{
		public static string Message(string error)
		{

			string result = error;
			result = error switch
			{
				var s when s.Contains("NumberPlate_Duplicate_1022") => "A placa informada já consta em nossa base de dados.",

			};

			return result;
		}
	}
}
