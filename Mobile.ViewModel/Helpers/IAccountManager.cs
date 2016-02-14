using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface IAccountManager
    { 
        Customer ActualLoggedUser { get; }
        Task LogUser(string login, string password);
        Task RegisterUser(string login, string password);

        Task RefreshCustomerAccount();
    }
}