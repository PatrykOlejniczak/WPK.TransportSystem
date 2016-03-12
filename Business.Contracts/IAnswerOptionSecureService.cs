using System.Collections.Generic;
using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IAnswerOptionSecureService
    {
        [OperationContract]
        IEnumerable<AnswerOption> GetAllWithDeleted();

        [OperationContract]
        void Create(AnswerOption answerOption);

        [OperationContract]
        void Update(AnswerOption answerOption);

        [OperationContract]
        void DeleteById(int id);

        [OperationContract]
        void UndeleteById(int id);
    }
}