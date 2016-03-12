using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IPhotoSecureService
    {
        [OperationContract]
        IEnumerable<Photo> GetAllWithDeleted();

        [OperationContract]
        void Create(Photo photo);

        [OperationContract]
        void Update(Photo photo);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}