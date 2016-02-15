using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusStopTypeSecureService
    {
        [OperationContract]
        IEnumerable<BusStopType> GetAllWithDeleted();

        [OperationContract]
        void Create(BusStopType busStopType);

        [OperationContract]
        void Update(BusStopType busStopType);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}