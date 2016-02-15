using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITicketSecureService
    {
        [OperationContract]
        IEnumerable<Ticket> GetAllWithDeleted();

        [OperationContract]
        void Create(Ticket ticket);

        [OperationContract]
        void Update(Ticket ticket);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}