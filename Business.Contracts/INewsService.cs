using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        IEnumerable<News> GetAll();

        [OperationContract]
        News GetById(int id);
    }
}