﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Model;

namespace Mobile.ViewModel.Helpers
{
    public interface ICustomerOperationProvider
    {
        Task<ObservableCollection<BoostAccount>> GetAllBoostAccountAsync();
        Task<ObservableCollection<PurchaseTicket>> GetAllPurchaseTicketAsync();
        Task<ObservableCollection<PurchaseTicket>> GetActivePurchaseTicketsAsync();
        Task CreateNewBoostAccount(string code);
        Task CreateNewPurchaseTicket(PurchaseTicket purchaseTicket, int howManyTickets);
    }
}