namespace RentH2.Domain.Utility
{
    public static class RentStatus
    {
        private readonly static List<string> _status = [];

        public const string Available = "Disponível";
        public const string Unavailable = "Indisponível";
        public const string Rented = "Locado";
        public const string Ended = "Finalizado";
        public const string Deleted = "Deletada";

        public static List<string> GetAllRentStatus() {

            _status.Add(Available);
            _status.Add(Unavailable);
            _status.Add(Rented);
            _status.Add(Ended);
            _status.Add(Deleted);
                
            return _status;
        }
    }
}
