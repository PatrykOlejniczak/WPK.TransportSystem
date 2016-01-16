using System.ServiceModel;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ICustomerAuthenticationService
    {
        [OperationContract]
        bool IsCustomerExists(string email);

        [OperationContract]
        bool IsCorrectCredentialsCorrect(string email, string password);

        [OperationContract]
        bool Register(string email, string password);

        [OperationContract]
        void SendPasswordReminder(string email);
    }
}