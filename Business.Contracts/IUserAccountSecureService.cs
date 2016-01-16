using Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IUserAccountSecureService
    {
        [OperationContract]
        IEnumerable<UserAccount> GetAll();

        [OperationContract]
        UserAccount GetById(int id);

        [OperationContract]
        UserAccount GetByEmployeeId(int employeeId);

        [OperationContract]
        void Create(UserAccount userAccount);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void DeleteByEmployeeId(int employeeId);
    }
}