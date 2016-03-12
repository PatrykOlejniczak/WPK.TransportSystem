using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface ITimetableService
    {
        [OperationContract]
        IEnumerable<Timetable> GetAll();

        [OperationContract]
        Timetable GetById(int id);
    }
}