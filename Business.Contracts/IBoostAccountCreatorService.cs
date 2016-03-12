using System.ServiceModel;

namespace Business.Contracts
{
    [ServiceContract]
    public interface IBoostAccountCreatorService
    {
        [OperationContract]
        string GetNewCodeFor(double amount);
    }
}