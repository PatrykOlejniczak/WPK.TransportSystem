using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ILineService
    {
        [OperationContract]
        IEnumerable<Line> GetAll();

        [OperationContract]
        Line GetById(int id);
    }
}