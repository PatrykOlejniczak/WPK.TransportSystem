using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITicketTypeService
    {
        [OperationContract]
        IEnumerable<TicketType> GetAll();

        [OperationContract]
        TicketType GetById(int id);

        [OperationContract]
        TicketType GetByName(string name);
    }
}