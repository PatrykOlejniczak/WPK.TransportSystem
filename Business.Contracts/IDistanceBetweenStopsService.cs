using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IDistanceBetweenStopsService
    {
        [OperationContract]
        IEnumerable<DistanceBetweenStops> GetAll();

        [OperationContract]
        DistanceBetweenStops GetById(int id);
    }
}