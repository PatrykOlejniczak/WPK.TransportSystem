using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface INewsSecureService
    {
        [OperationContract]
        IEnumerable<News> GetAllWithDeleted();

        [OperationContract]
        IEnumerable<News> GetByEmployeeId(int employeeId);

        [OperationContract]
        void Create(News news);

        [OperationContract]
        void Update(News news);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}