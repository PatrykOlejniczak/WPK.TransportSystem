using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        private string _loginErrorMessage;
        public string LoginErrorMessage
        {
            get
            {
                return _loginErrorMessage;
            }
            set
            {
                if (!Equals(value, _loginErrorMessage))
                {
                    _loginErrorMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

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

        private string _registerErrorMessage;

        public string RegisterErrorMessage
        {
            get { return _registerErrorMessage; }
            set
            {
                if (_registerErrorMessage != value)
                {
                    _registerErrorMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _registerEmail;
        public string RegisterEmail
        {
            get { return _registerEmail; }
            set
            {
                if (_registerEmail != value)
                {
                    _registerEmail = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
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

        private void ExecuteLogUser(IPasswordGuardian parameter)
        {
            LoginErrorMessage = null;
            
            IsLoginInputCorrect(parameter);

            if (string.IsNullOrEmpty(LoginErrorMessage))
            {
                TryLogUser(parameter);
            }
        }

        private void IsLoginInputCorrect(IPasswordGuardian parameter)
        {
            var password = parameter.Password;

            if (!(password != null && LoginEmail != null && IsCorrectEmailFormat(LoginEmail)))
            {
                LoginErrorMessage = "Incorrect username or password format.";
            }         
        }

        private bool IsCorrectEmailFormat(string email)
        {
            return Regex.IsMatch(
                email, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                RegexOptions.IgnoreCase);
        }

        private async void TryLogUser(IPasswordGuardian parameter)
        {
            var password = parameter.Password;

            try
            {
                IsLoading = true;

                await _accountManager.LogUser(LoginEmail, password);

                ExecuteNavigateToMainMenu();
            }
            catch (Exception exception)
            {
                LoginErrorMessage = exception.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ExecuteRegisterUser(IPasswordGuardian parameter)
        {
            RegisterErrorMessage = null;

            IsRegisterInputCorrect(parameter);

            if (string.IsNullOrEmpty(RegisterErrorMessage))
            {
                TryRegisterCustomer(parameter);
            }
        }

        private async void TryRegisterCustomer(IPasswordGuardian parameter)
        {
            var password = parameter.Password;

            try
            {
                IsLoading = true;

                await _accountManager.RegisterUser(RegisterEmail, password);

                ExecuteNavigateToMainMenu();
            }
            catch (Exception exception)
            {
                RegisterErrorMessage = exception.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void IsRegisterInputCorrect(IPasswordGuardian parameter)
        {
            var password = parameter.Password;

            if (!(password != null && RegisterEmail != null && IsCorrectEmailFormat(RegisterEmail)))
            {
                RegisterErrorMessage = "Incorrect username or password format.";
            }
        }
    }
}