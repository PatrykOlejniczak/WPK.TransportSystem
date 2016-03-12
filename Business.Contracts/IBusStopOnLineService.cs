using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusStopOnLineService
    {
        [OperationContract]
        IEnumerable<BusStopOnLine> GetAll();

        [OperationContract]
        BusStopOnLine GetById(int id);
    }
}