using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IQuestionnaireSecureService
    {
        [OperationContract]
        IEnumerable<Questionnaire> GetAllWithDeleted();

        [OperationContract]
        IEnumerable<Questionnaire> GetByEmployeeId(int employeeId);

        [OperationContract]
        void Create(Questionnaire questionnaire);

        [OperationContract]
        void Update(Questionnaire questionnaire);

        [OperationContract]
        void DelteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}