﻿using System.ServiceModel;

namespace Mobile.Helper.Services.ServiceConfiguration
{
    public static class EndPoints
    {
         public static EndpointAddress CustomerOperation = 
            new EndpointAddress("http://localhost:24462/Services/CustomerOperationService.svc/basicHttp");

        public static EndpointAddress CustomerAuthentication =
            new EndpointAddress("http://localhost:24462/Services/CustomerAuthenticationService.svc/basicHttp");

        public static EndpointAddress TicketService =
            new EndpointAddress("http://localhost:24462/Services/TicketService.svc/basicHttp");

        public static EndpointAddress LineService =
            new EndpointAddress("http://localhost:24462/Services/LineService.svc/basicHttp");
    }
}