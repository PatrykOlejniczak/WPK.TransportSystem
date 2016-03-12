using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IAnswerOptionService
    {
        [OperationContract]
        IEnumerable<AnswerOption> GetAll();

        [OperationContract]
        IEnumerable<AnswerOption> GetByQuestionnaireId(int questionnaireId);

        [OperationContract]
        AnswerOption GetById(int id);
    }
}