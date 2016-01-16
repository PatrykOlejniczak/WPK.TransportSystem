using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;

namespace Mobile.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand NavigateToMainMenu { get; private set; }
        public ICommand LogUser { get; private set; }
        public ICommand RegisterUser { get; private set; }

        private readonly IExpandedNavigation _navigationService;
        private readonly IAccountManager _accountManager;

        private string _loginEmail;
        public string LoginEmail
        {
            get { return _loginEmail; }
            set
            {
                if (value != _loginEmail)
                {
                    _loginEmail = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _registerEmail;

        public string RegisterEmail
        {
            get { return _registerEmail; }
            private set
            {
                if (_registerEmail != value)
                {
                    _registerEmail = value;
                    RaisePropertyChanged();
                }
            }
        }

        public LoginViewModel(
            IExpandedNavigation navigationService, IAccountManager accountManager)
        {
            _navigationService = navigationService;
            _accountManager = accountManager;

            NavigateToMainMenu
                = new RelayCommand(ExecuteNavigateToMainMenu);

            LogUser
                = new RelayCommand<IPasswordGuardian>(ExecuteLogUser);

            RegisterUser
                = new RelayCommand<IPasswordGuardian>(ExecuteRegisterUser);
        }

        private void ExecuteNavigateToMainMenu()
        {
            _navigationService.NavigateTo("MainMenuView");
        }

        private async void ExecuteLogUser(IPasswordGuardian parameter)
        {
            var password = parameter.Password;

            if (password != null && LoginEmail != null)
            {

                bool isCorrect = await _accountManager.LogUser(LoginEmail, password);
                Messenger.Default.Send((Customer)_accountManager.ActualLoggedUser);
                if (isCorrect)
                {
                    ExecuteNavigateToMainMenu();
                }
            }
        }

        private async void ExecuteRegisterUser(IPasswordGuardian parameter)
        {
            //TODO
        }
    }
}