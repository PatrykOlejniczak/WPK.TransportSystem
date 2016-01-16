using System;
using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBoostAccountSecureService
    {
        [OperationContract]
        IEnumerable<BoostAccount> GetAll();

        [OperationContract]
        IEnumerable<BoostAccount> GetLastest(int number);

        [OperationContract]
        IEnumerable<BoostAccount> GetActivatedAfterDate(DateTime dateTime);

        [OperationContract]
        IEnumerable<BoostAccount> GetActivatedToDate(DateTime dateTime);

        [OperationContract]
        IEnumerable<BoostAccount> GetWithUsedCode();

        [OperationContract]
        IEnumerable<BoostAccount> GetWithNotUsedCode();

        [OperationContract]
        IEnumerable<BoostAccount> GetGeneratedAfterDate(DateTime dateTime);

        [OperationContract]
        IEnumerable<BoostAccount> GetGeneratedToDate(DateTime dateTime);

        [OperationContract]
        IEnumerable<BoostAccount> GetWhereAmountMoreThan(double amount);

        [OperationContract]
        IEnumerable<BoostAccount> GetWhereAmountLessThan(double amount);

        [OperationContract]
        BoostAccount GetById(int id);

        [OperationContract]
        BoostAccount GetByCustomer(int cutomerId);
    }
}