using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IQuestionnaireService
    {
        [OperationContract]
        IEnumerable<Questionnaire> GetAll();

        [OperationContract]
        Questionnaire GetById(int id);
    }
}