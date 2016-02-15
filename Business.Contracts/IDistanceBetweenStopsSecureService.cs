using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IDistanceBetweenStopsSecureService
    {
        [OperationContract]
        IEnumerable<DistanceBetweenStops> GetAllWithDeleted();

        [OperationContract]
        void Create(DistanceBetweenStops distanceBetweenStops);

        [OperationContract]
        void Update(DistanceBetweenStops distanceBetweenStops);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}