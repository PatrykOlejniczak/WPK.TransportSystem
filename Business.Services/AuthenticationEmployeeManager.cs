using Business.Contracts;

namespace Business.Services
{
    public class AuthenticationEmployeeManager
        : IEmployeeAuthentication
    {
        public bool IsAccountExists(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmployeeHaveAccount(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCorrectCredentialsCorrect(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}