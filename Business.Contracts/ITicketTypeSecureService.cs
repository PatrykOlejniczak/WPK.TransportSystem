using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITicketTypeSecureService
    {
        [OperationContract]
        void Create(TicketType ticketType);

        [OperationContract]
        void Update(TicketType ticketType);

        [OperationContract]
        void DeleteById(int id);
    }
}