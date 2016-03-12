using System;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IPurchaseTicketSecureService
    {
        [OperationContract]
        IEnumerable<PurchaseTicket> GetAll();

        [OperationContract]
        IEnumerable<PurchaseTicket> GetToDate(DateTime dateTime);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetAfterDate(DateTime dateTime);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetByFirstName(string firstName);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetByLastName(string lastName);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetFromDevice(string deviceId);

        [OperationContract]
        PurchaseTicket GetById(int id);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetByCustomerId(int customerId);

        [OperationContract]
        IEnumerable<PurchaseTicket> GetFromDate(DateTime dateTime);
    }
}