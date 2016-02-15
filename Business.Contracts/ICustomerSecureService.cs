using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ICustomerSecureService
    {
        [OperationContract]
        IEnumerable<Customer> GetAll();

        [OperationContract]
        IEnumerable<Customer> GetAllWithDeleted();

        [OperationContract]
        IEnumerable<Customer> GetWhereAccountBallanceMoreThan(double ballance);

        [OperationContract]
        IEnumerable<Customer> GetWhereAccountBallanceLessThan(double ballance);

        [OperationContract]
        Customer GetById(int id);

        [OperationContract]
        Customer GetByEmail(string email);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}