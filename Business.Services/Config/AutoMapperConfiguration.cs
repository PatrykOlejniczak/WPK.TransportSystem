using System;
using Business.Entities;
using Data.Core.Converters;

namespace Business.Services.Config
{
    public static class AutoMapperConfiguration
    {
        public static void AutoConfig()
        {
            ConfigAnswerOptionMapping();
            ConfigBuStopMapping();
            ConfigBusStopOnLineMapping();
            ConfigLineMapping();
            ConfigBusStopTypeMapping();
            ConfigPhotoMapping();
            ConfigUserAccount();
            ConfigQuestionnaireMapping();
            ConfigBoostAccountMapping();
            ConfigCustomerMapping();
            ConfigNewsMapping();
            ConfigEmployeeMapping();
            ConfigDiscountMapping();
            ConfigDurationTimeSpanMapping();
            ConfigPurchaseTicketMapping();
            ConfigTicketMapping();
            ConfigDistanceBetweenStopsMapping();
            ConfigTicketTypeMapping();
        }

        private static void ConfigTimetable()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Timetable, Timetable>();

            AutoMapper.Mapper.CreateMap
                <Timetable, Data.Entities.Timetable>();
        }

        private static void ConfigUserAccount()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.UserAccount, UserAccount>();
            AutoMapper.Mapper.CreateMap
                <UserAccount, Data.Entities.UserAccount>();
        }

        private static void ConfigQuestionnaireMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Questionnaire, Questionnaire>();
            AutoMapper.Mapper.CreateMap
                <Questionnaire, Data.Entities.Questionnaire>();
        }

        private static void ConfigPhotoMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Photo, Photo>();
            AutoMapper.Mapper.CreateMap
                <Photo, Data.Entities.Photo>();
        }

        private static void ConfigNewsMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.News, News>();
            AutoMapper.Mapper.CreateMap
                <News, Data.Entities.News>();
        }

        private static void ConfigLineMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Line, Line>();
            AutoMapper.Mapper.CreateMap
                <Line, Data.Entities.Line>();
        }

        private static void ConfigEmployeeMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Employee, Employee>();
            AutoMapper.Mapper.CreateMap
                <Employee, Data.Entities.Employee>();
        }

        private static void ConfigDistanceBetweenStopsMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.DistanceBetweenStops, DistanceBetweenStops>();
            AutoMapper.Mapper.CreateMap
                <DistanceBetweenStops, Data.Entities.DistanceBetweenStops>();
        }

        private static void ConfigBusStopTypeMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.BusStopType, BusStopType>();
            AutoMapper.Mapper.CreateMap
                <BusStopType, Data.Entities.BusStopType>();
        }

        private static void ConfigBusStopOnLineMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.BusStopOnLine, BusStopOnLine>();
            AutoMapper.Mapper.CreateMap
                <BusStopOnLine, Data.Entities.BusStopOnLine>();
        }

        private static void ConfigBuStopMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.BusStop, BusStop>();
            AutoMapper.Mapper.CreateMap
                <BusStop, Data.Entities.BusStop>();
        }

        private static void ConfigAnswerOptionMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.AnswerOption, AnswerOption>();
            AutoMapper.Mapper.CreateMap
                <AnswerOption, Data.Entities.AnswerOption>();
        }

        private static void ConfigCustomerMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Customer, Customer>();
            AutoMapper.Mapper.CreateMap
                <Customer, Data.Entities.Customer>();
        }

        private static void ConfigBoostAccountMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.BoostAccount, BoostAccount>();
            AutoMapper.Mapper.CreateMap
                <BoostAccount, Data.Entities.BoostAccount>();
        }

        private static void ConfigPurchaseTicketMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.PurchaseTicket, PurchaseTicket>();
            AutoMapper.Mapper.CreateMap
                <PurchaseTicket, Data.Entities.PurchaseTicket>();
        }

        private static void ConfigDiscountMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Discount, Discount>();

            AutoMapper.Mapper.CreateMap
                <Discount, Data.Entities.Discount>();
        }

        private static void ConfigTicketMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Ticket, Ticket>();

            AutoMapper.Mapper.CreateMap
                <Ticket, Data.Entities.Ticket>();
        }

        private static void ConfigTicketTypeMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.TicketType, TicketType>();

            AutoMapper.Mapper.CreateMap
                <TicketType, Data.Entities.TicketType>();
        }

        private static void ConfigDurationTimeSpanMapping()
        {
            AutoMapper.Mapper.CreateMap
                <Data.Entities.Duration, TimeSpan>()
                .ConvertUsing<DurationToTimeSpanConverter>();

            AutoMapper.Mapper.CreateMap
                <TimeSpan, Data.Entities.Duration>()
                .ConvertUsing<TimeSpanToDurationConverter>();
        }

    }
}