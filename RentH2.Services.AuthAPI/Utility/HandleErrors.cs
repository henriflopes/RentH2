namespace RentH2.Services.AuthAPI.Utility
{
    public static class HandleErrors
    {
        public static string Message(string error)
        {

            string result = error;
            result = error switch
            {
				var s when s.Contains("AK_AspNetUsers_DriverLicenseId") => "Carteira de Motorista já cadastrada em nossa base de dados.",
				var s when s.Contains("AK_AspNetUsers_DocumentId") => "Já existe o CNPJ cadastrado em nossa base de dados."
			};

            return result;
        }
    }
}
