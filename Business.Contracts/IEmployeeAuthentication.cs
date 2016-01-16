using System.ServiceModel;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IEmployeeAuthentication
    {
        [OperationContract]
        bool IsAccountExists(string email);

        [OperationContract]
        bool IsEmployeeHaveAccount(int employeeId);

        [OperationContract]
        bool IsCorrectCredentialsCorrect(string email, string password);
    }
}