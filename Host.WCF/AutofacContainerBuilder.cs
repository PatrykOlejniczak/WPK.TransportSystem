using Autofac;
using Business.Contracts;
using Business.Services;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Host.WCF
{
    public static class AutofacContainerBuilder
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataContext>()
                .As<IUnitOfWork>();

            builder.RegisterType<Repository<AnswerOption>>()
                .As<IRepository<AnswerOption>>();
            builder.RegisterType<Repository<BoostAccount>>()
                .As<IRepository<BoostAccount>>();
            builder.RegisterType<Repository<BusStop>>()
                .As<IRepository<BusStop>>();
            builder.RegisterType<Repository<BusStopOnLine>>()
                .As<IRepository<BusStopOnLine>>();
            builder.RegisterType<Repository<BusStopType>>()
                .As<IRepository<BusStopType>>();
            builder.RegisterType<Repository<Customer>>()
                .As<IRepository<Customer>>();
            builder.RegisterType<Repository<Discount>>()
                .As<IRepository<Discount>>();
            builder.RegisterType<Repository<DistanceBetweenStops>>()
                .As<IRepository<DistanceBetweenStops>>();
            builder.RegisterType<Repository<Employee>>()
                .As<IRepository<Employee>>();
            builder.RegisterType<Repository<Line>>()
                .As<IRepository<Line>>();
            builder.RegisterType<Repository<News>>()
                .As<IRepository<News>>();
            builder.RegisterType<Repository<Photo>>()
                .As<IRepository<Photo>>();
            builder.RegisterType<Repository<PurchaseTicket>>()
                .As<IRepository<PurchaseTicket>>();
            builder.RegisterType<Repository<Questionnaire>>()
                .As<IRepository<Questionnaire>>();
            builder.RegisterType<Repository<Ticket>>()
                .As<IRepository<Ticket>>();
            builder.RegisterType<Repository<TicketType>>()
                .As<IRepository<TicketType>>();
            builder.RegisterType<Repository<Timetable>>()
                .As<IRepository<Timetable>>();
            builder.RegisterType<Repository<UserAccount>>()
                .As<IRepository<UserAccount>>();

            builder.RegisterType<AuthenticationEmployeeManager>()
                .As<IEmployeeAuthentication>();
            builder.RegisterType<AuthenticationCustomerManager>()
                .As<ICustomerAuthenticationService>();

            builder.RegisterType<AnswerOptionManager>();
            builder.RegisterType<BoostAccountManager>()
                .As<IBoostAccountSecureService>()
                .As<IBoostAccountCreatorService>();
            builder.RegisterType<BusStopOnLineManager>();
            builder.RegisterType<BusStopManager>();
            builder.RegisterType<BusStopTypeManager>();
            builder.RegisterType<CustomerManager>()
                .As<ICustomerSecureService>();
            builder.RegisterType<CustomerOperationService>()
                .As<ICustomerOperationService>();
            builder.RegisterType<DiscountManager>();
            builder.RegisterType<DistanceBetweenStopsManager>();
            builder.RegisterType<EmployeeManager>()
                .As<IEmployeeSecureService>();
            builder.RegisterType<PhotoManager>();
            builder.RegisterType<LineManager>();
            builder.RegisterType<NewsManager>();
            builder.RegisterType<QuestionnaireManager>();
            builder.RegisterType<PurchaseTicketManager>()
                .As<IPurchaseTicketSecureService>();
            builder.RegisterType<TicketManager>();
            builder.RegisterType<TicketTypeManager>();
            builder.RegisterType<TimetableManager>();
            builder.RegisterType<UserAccountManager>()
                .As<IUserAccountSecureService>();


            return builder.Build();
        }
    }
}