using System.ServiceModel;
using Business.Entities;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IAnswerOptionSecureService
    {
        [OperationContract]
        void Create(AnswerOption answerOption);

        [OperationContract]
        void Update(AnswerOption answerOption);

        [OperationContract]
        void DeleteById(int id);
    }
}