using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBusStopTypeService
    {
        [OperationContract]
        IEnumerable<BusStopType> GetAll();

        [OperationContract]
        BusStopType GetById(int id);
    }
}