namespace RentH2.Domain.Entities.Validators
{
    public class ExceptionDomain : ArgumentException
    {
        public List<string> ErrorMessages { get; set; }

        public ExceptionDomain(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}