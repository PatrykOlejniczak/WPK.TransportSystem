using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IDiscountService
    {
        [OperationContract]
        IEnumerable<Discount> GetAll();

        [OperationContract]
        IEnumerable<Discount> GetWherePercentMoreThan(double percent);

        [OperationContract]
        IEnumerable<Discount> GetWherePercentLessThan(double percent);

        [OperationContract]
        Discount GetById(int id);

        [OperationContract]
        Discount GetByName(string name);
    }
}