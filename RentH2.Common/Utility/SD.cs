namespace RentH2.Common.Utility
{
    public class SD
    {
        public const string TokenCookie = "JWTToken";
        public static string AuthAPIBase { get; set; }
        public static string ProductAPIBase { get; set; }
        public static string ShoppingCartAPIBase { get; set; }
        public static string OrderAPIBase { get; set; }
        public static string RentAPIBase { get; set; }
        public static string MotorcycleAPIBase { get; set; }
        public static string PlanAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        public enum ContentType
        {
            Json,
            MultipartFormData
        }
    }
}
