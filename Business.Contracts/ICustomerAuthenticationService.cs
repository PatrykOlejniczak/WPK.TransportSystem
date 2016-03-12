using System.ServiceModel;
using Business.Entities;

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
        Customer GetInfoAboutCustomer(string email, string password);

        [OperationContract]
        bool Register(string email, string password);

        [OperationContract]
        void SendPasswordReminder(string email);
    }
}