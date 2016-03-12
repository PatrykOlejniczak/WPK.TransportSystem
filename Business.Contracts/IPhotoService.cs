using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IPhotoService
    {
        [OperationContract]
        IEnumerable<Photo> GetAll();

        [OperationContract]
        IEnumerable<Photo> GetByNewsId(int newsId);

        [OperationContract]
        Photo GetById(int id);
    }
}