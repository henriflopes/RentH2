using RentH2.Domain.Entities.Validators;

namespace RentH2.Domain.Test._Utility
{
    public static class AssertExtension
    {
        public static void WithMessage(this ExceptionDomain exception, string message)
        {
            if(exception.ErrorMessages.Contains(message))
                Assert.True(true);
            else
                Assert.False(true, $"The expected message was '{message}'");
        }

        
    }
}
