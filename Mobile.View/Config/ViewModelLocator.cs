using System.ServiceModel;
using Windows.UI.Xaml;
using Autofac;
using GalaSoft.MvvmLight;
using Mobile.Helper.Services.CustomerOperationService;
using Mobile.Helper.Services.InjectProviders;
using Mobile.Helper.Services.TicketService;
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

            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {

            }
            
            builder.RegisterType<BoostAccountViewModel>();
            builder.RegisterType<ChooseTicketTypeViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainMenuViewModel>();
            builder.RegisterType<PurchaseHistoryViewModel>();
            builder.RegisterType<TimetableViewModel>();

            _container = builder.Build();
        }

        private async void Test(CustomerOperationServiceClient c)
        {
            var w = await c.GetAllPurchaseTicketAsync();

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

            return navigationService;
        }

    }
}