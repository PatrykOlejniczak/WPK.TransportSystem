using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IEmployeeSecureService
    {
        [OperationContract]
        IEnumerable<Employee> GetAll();

        [OperationContract]
        Employee GetById(int id);

        [OperationContract]
        void Create(Employee employee);

        [OperationContract]
        void Update(Employee employee);
    }
}