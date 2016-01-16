using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusStopSecureService
    {
        [OperationContract]
        void Create(BusStop busStop);

        [OperationContract]
        void Update(BusStop busStop);

        [OperationContract]
        void DeleteById(int id);
    }
}