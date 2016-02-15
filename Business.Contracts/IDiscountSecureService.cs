using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IDiscountSecureService
    {
        [OperationContract]
        IEnumerable<Discount> GetAllWithDeleted();

        [OperationContract]
        void Create(Discount discount);

        [OperationContract]
        void Update(Discount discount);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}