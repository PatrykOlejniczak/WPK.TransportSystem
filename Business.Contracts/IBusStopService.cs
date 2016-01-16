using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusStopService
    {
        [OperationContract]
        IEnumerable<BusStop> GetAll();

        [OperationContract]
        BusStop GetById(int id);
    }
}