using Windows.UI.Xaml;
using Autofac;
using GalaSoft.MvvmLight;
using Mobile.Helper.Services.InjectProviders;
using Mobile.View.Helpers;
using Mobile.ViewModel;
using Mobile.ViewModel.Helpers;


namespace Mobile.View.Config
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance
            => Application.Current.Resources["ViewModelLocator"] as ViewModelLocator;

        private readonly IContainer _container;

        public LoginPanelViewModel LoginPanel
            => _container.Resolve<LoginPanelViewModel>();

        public FinalizationTransactionViewModel FinalizationTransaction
            => _container.Resolve<FinalizationTransactionViewModel>();

        public BuyTicketCountViewModel BuyTicketCount
            => _container.Resolve<BuyTicketCountViewModel>();

        public BoostAccountViewModel BoostAccount
            => _container.Resolve<BoostAccountViewModel>();

        public ChooseTicketTypeViewModel ChooseTicketType
            => _container.Resolve<ChooseTicketTypeViewModel>();

        public LoginViewModel Login
            => _container.Resolve<LoginViewModel>();

        public MainMenuViewModel MainMenu
            => _container.Resolve<MainMenuViewModel>();

        public PurchaseHistoryViewModel PurchaseHistory 
            => _container.Resolve<PurchaseHistoryViewModel>();

        public LineDetailsViewModel LineDetails
            => _container.Resolve<LineDetailsViewModel>();

        public TimetableViewModel Timetable
            => _container.Resolve<TimetableViewModel>();

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            var navigationService = CreateNavigationService();

            builder.RegisterInstance(navigationService)
                .As<IExpandedNavigation>();            

            builder.RegisterType<TicketProvider>()
                .As<ITicketProvider>();
            builder.RegisterType<CustomerOperationProvider>()
                .As<ICustomerOperationProvider>();
            builder.RegisterType<TimetableProvider>()
                .As<ITimetableProvider>();
            builder.RegisterType<AccountManager>()
                .As<IAccountManager>().SingleInstance();
            builder.RegisterType<LineProvider>()
                .As<ILineProvider>();
            builder.RegisterType<DeviceManager>()
                .As<IDeviceManager>();

            builder.RegisterType<BoostAccountViewModel>().SingleInstance();
            builder.RegisterType<ChooseTicketTypeViewModel>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<MainMenuViewModel>().SingleInstance();
            builder.RegisterType<PurchaseHistoryViewModel>().SingleInstance();
            builder.RegisterType<TimetableViewModel>().SingleInstance();
            builder.RegisterType<BuyTicketCountViewModel>().SingleInstance();
            builder.RegisterType<FinalizationTransactionViewModel>().SingleInstance();
            builder.RegisterType<LoginPanelViewModel>().SingleInstance();
            builder.RegisterType<LineDetailsViewModel>().SingleInstance();

            _container = builder.Build();

            var test = LoginPanel;
            var test4 = BuyTicketCount;
            var test2 = FinalizationTransaction;
            var test3 = BoostAccount;
        }

        private IExpandedNavigation CreateNavigationService()
        {
            var navigationService = new ExpandedNavigation();

            navigationService.Configure("BoostAccountView", typeof(View.BoostAccountView));
            navigationService.Configure("ChooseTicketTypeView", typeof(View.ChooseTicketTypeView));
            navigationService.Configure("LoginView", typeof(View.LoginView));
            navigationService.Configure("MainMenuView", typeof(View.MainMenuView));
            navigationService.Configure("PurchaseHistoryView", typeof(View.PurchaseHistoryView));
            navigationService.Configure("TimetableView", typeof(View.TimetableView));
            navigationService.Configure("BuyTicketCountView", typeof(View.BuyTicketCountView));
            navigationService.Configure("FinalizationTransactionView", typeof(View.FinalizationTransactionView));
            navigationService.Configure("LineDetailsView", typeof(View.LineDetailsView));

            return navigationService;
        }

    }
}