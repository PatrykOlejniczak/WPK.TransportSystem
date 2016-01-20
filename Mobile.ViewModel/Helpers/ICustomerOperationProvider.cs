using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoMapper;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface ICustomerOperationProvider
    {
        Task<ObservableCollection<BoostAccount>> GetAllBoostAccountAsync();
        Task<ObservableCollection<PurchaseTicket>> GetAllPurchaseTicketAsync();
        Task UpdateCustomerEmail(string email);
        Task CreateNewBoostAccount(string code);
        Task CreateNewPurchaseTicket(PurchaseTicket purchaseTicket, int howManyTickets);
    }
}