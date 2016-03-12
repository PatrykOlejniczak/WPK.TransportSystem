using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITimetableSecureService
    {
        [OperationContract]
        IEnumerable<Timetable> GetAllWithDeleted();

        [OperationContract]
        void Create(Timetable timetable);

        [OperationContract]
        void Update(Timetable timetable);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}