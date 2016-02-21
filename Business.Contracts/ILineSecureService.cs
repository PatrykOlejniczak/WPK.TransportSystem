using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ILineSecureService
    {
        [OperationContract]
        IEnumerable<Line> GetAllWithDeleted();

        [OperationContract]
        void Create(Line line);

        [OperationContract]
        void Update(Line line);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}