using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface IAccountManager
    { 
        bool IsUserLogged { get; }
        Customer ActualLoggedUser { get; }
        Task<bool> LogUser(string login, string password);
        Task RegisterUser(string login, string password);
    }
}