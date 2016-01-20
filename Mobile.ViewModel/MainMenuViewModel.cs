﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        private ObservableCollection<PurchaseTicket> _activePurchaseTickets;

        public ObservableCollection<PurchaseTicket> ActivePurchaseTickets
        {
            get { return _activePurchaseTickets; }
            private set
            {
                if (_activePurchaseTickets != value)
                {
                    _activePurchaseTickets = value;
                }

                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _favouriteLines;

        public ObservableCollection<string> FavouriteLines
        {
            get { return _favouriteLines; }
            private set
            {
                if (_favouriteLines != value)
                {
                    _favouriteLines = value;
                }

                RaisePropertyChanged();
            }
        }

        public ICommand NavigateToPurchaseHistory { get; private set; }
        public ICommand NavigateToTimetable { get; private set; }
        public ICommand NavigateToBuyTicket { get; private set; }
        public ICommand NavigateToBoostAccount { get; private set; }

        private readonly IExpandedNavigation _navigationService;
        private readonly IAccountManager _accountManager;
        private readonly ICustomerOperationProvider _customerOperationProvider;

        public MainMenuViewModel(
            IExpandedNavigation navigationService, ICustomerOperationProvider customerOperationProvider, IAccountManager accountManager)
        {
            _navigationService = navigationService;
            _customerOperationProvider = customerOperationProvider;
            _accountManager = accountManager;

            NavigateToPurchaseHistory
                = new RelayCommand(ExecuteNavigateToPurchaseHistory);

            NavigateToBoostAccount
                = new RelayCommand(ExecuteNavigateToBoostAccount);

            NavigateToBuyTicket
                = new RelayCommand(ExecuteNavigateToBuyTicket);

            NavigateToTimetable
                = new RelayCommand(ExecuteNavigateToTimetable);

            ActivePurchaseTickets = new ObservableCollection<PurchaseTicket>();
        }

        private void ExecuteNavigateToPurchaseHistory()
        {
            _navigationService.NavigateTo("PurchaseHistoryView");
        }

        private void ExecuteNavigateToTimetable()
        {
            _navigationService.NavigateTo("TimetableView");
        }

        private void ExecuteNavigateToBuyTicket()
        {
            _navigationService.NavigateTo("ChooseTicketTypeView");
        }

        private void ExecuteNavigateToBoostAccount()
        {
            _navigationService.NavigateTo("BoostAccountView");
        }

        private async void DownloadActiveTickets()
        {
            //ActivePurchaseTickets = await _customerOperationProvider.GetAllPurchaseTicketAsync();
        }
    }
}