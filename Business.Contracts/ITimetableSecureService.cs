using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITimetableSecureService
    {
        [OperationContract]
        void Create(Timetable timetable);

        [OperationContract]
        void Update(Timetable timetable);

        [OperationContract]
        void DeleteById(int id);
    }
}