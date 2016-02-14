using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ManagingSystem.Pages.UserControls;

namespace ManagingSystem.Class
{
    class UserControlManager
    {
        public ClientsControl Clients { get; private set; }
        public EmployeesControl Employees { get; private set; }
        public NewsControl News { get; private set; }
        public UserControl Schedule { get; private set; }
        public UserControl Statistics { get; private set; }
        public UserControl Survey { get; private set; }
        public TicketsControl Tickets { get; private set; }

        public UserControlManager()
        {
            //Clients = new ClientsControl();
            //Employees = new EmployeesControl();
            //News = new NewsControl();
            //Schedule = new ScheduleControl();
            //Statistics = new StatisticsControl();
            //Survey = new SurveyControl();
            //Tickets = new TicketsControl();
        }

        public void OpenEmployees(string login, string password)
        {
            Employees = new EmployeesControl();
            Employees.UpdateUserCredentials(login,password);
            Employees.FillData();
        }

        public void OpenTickets(string login, string password)
        {
            Tickets = new TicketsControl();
            Tickets.UpdateUserCredentials(login, password);
            Tickets.FillData();
        }

        public void OpenNews(string login, string password)
        {
            News = new NewsControl();
            News.UpdateUserCredentials(login, password);
            News.FillData();
        }

        public void OpenClients(string login, string password)
        {
            Clients = new ClientsControl();
            Clients.UpdateUserCredentials(login, password);
            Clients.FillData();
        }
    }
}
