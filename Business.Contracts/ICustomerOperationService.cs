using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ICustomerOperationService
    {
        [OperationContract]
        IEnumerable<BoostAccount> GetAllBoostAccount(string userName, string password);

        [OperationContract]
        IEnumerable<ExpandedPurchaseTicket> GetAllPurchaseTicket(string userName, string password);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetActivePurchaseTicket(string userName, string password, string deviceId);

        [OperationContract]
        double GetAccountBallance(string userName, string password);

        [OperationContract]
        void UpdateCustomerEmail(string userName, string password, string email);

        [OperationContract]
        void UpdateCustomerPassword(string userName, string password, string newPassword);

        [OperationContract]
        void CreateNewBoostAccount(string userName, string password, string code);

        [OperationContract]
        void CreateNewPurchaseTicket(string userName, string password, PurchaseTicket purchaseTicket, int howManyTickets);
    }
}