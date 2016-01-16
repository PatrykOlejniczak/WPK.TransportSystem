using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusStopOnLineSecureService
    {
        [OperationContract]
        void Create(BusStopOnLine busStopOnLine);

        [OperationContract]
        void Update(BusStopOnLine busStopOnLine);

        [OperationContract]
        void DeleteById(int id);
    }
}