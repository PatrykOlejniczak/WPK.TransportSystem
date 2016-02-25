using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Mobile.Model;
using Mobile.ViewModel.Helpers;
using Mobile.ViewModel.Messages;

namespace Mobile.ViewModel
{
    public class ChooseLineViewModel : ViewModelBase
    {
        public ICommand NavigateToLineDetails { get; private set; }

        private ObservableCollection<Line> _lines;
        public ObservableCollection<Line> Lines
        {
            get { return _lines; }
            set
            {
                if (value != null && _lines != value)
                {
                    _lines = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Line _selectedLine;
        public Line SelectedLine
        {
            get
            {
                return _selectedLine;
            }
            set
            {
                _selectedLine = value;
                RaisePropertyChanged();
                NavigateToLineDetails.Execute(null);
            }
        }

        private readonly IExpandedNavigation _navigationService;
        private readonly ILineProvider _lineProvider;

        public ChooseLineViewModel(IExpandedNavigation navigationService,
            ILineProvider lineProvider)
        {
            _navigationService = navigationService;
            _lineProvider = lineProvider;

            Lines = new ObservableCollection<Line>();

            NavigateToLineDetails
                = new RelayCommand(ExecuteNavigateToLineDetails);

            DownloadTickets();
        }

        private async void DownloadTickets()
        {
            Lines = await _lineProvider.GetAllAsync();
        }

        private void ExecuteNavigateToLineDetails()
        {
            SendMessage();
            _navigationService.NavigateTo("LineDetailsView");
        }

        private void SendMessage()
        {
            Messenger.Default.Send(new LineStatus()
            {
                Line = SelectedLine
            });
        }
    }
}