using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITicketService
    {
        [OperationContract]
        IEnumerable<Ticket> GetAll();

        [OperationContract]
        IEnumerable<Ticket> GetWherePriceMoreThan(double price);

        [OperationContract]
        IEnumerable<Ticket> GetWherePriceLessThan(double price);

        [OperationContract]
        IEnumerable<Ticket> GetWhereTicketTypeId(int ticketTypeId);

        [OperationContract]
        Ticket GetById(int id);

        [OperationContract]
        Ticket GetByName(string name);

    }
}
