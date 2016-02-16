using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ManagingSystem.Pages.UserControls;
using System.ServiceModel.Description;

namespace ManagingSystem.Class
{
    class UserControlManager
    {
        public ClientsControl Clients { get; private set; }
        public EmployeesControl Employees { get; private set; }
        public NewsControl News { get; private set; }
        public BusSchedule BusSchedule { get; private set; }
        public StatisticsUserControl Statistics { get; private set; }
        public QuestionnaireUserControl Questionnaire { get; private set; }
        public TicketsControl Tickets { get; private set; }
        public CareerUserControl Career { get; private set; }

        private ClientCredentials clientCredentials{ get; set; }

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

        public void SetClientCredentials(ClientCredentials _clientCredentials)
        {
            this.clientCredentials = _clientCredentials;
        }

        public void OpenSchedule() //EmptyDATABASE
        {
            BusSchedule = new BusSchedule();
            BusSchedule.UpdateUserCredentials(clientCredentials);
            BusSchedule.FillData();
        }

        public void OpenEmployees()
        {
            Employees = new EmployeesControl();
            Employees.UpdateUserCredentials(clientCredentials);
            Employees.FillData();
        }

        public void OpenTickets()
        {
            Tickets = new TicketsControl();
            Tickets.UpdateUserCredentials(clientCredentials);
            Tickets.FillData();
        }

        public void OpenNews()
        {
            News = new NewsControl();
            News.UpdateUserCredentials(clientCredentials);
            News.FillData();
        }

        public void OpenCareer()
        {
            Career = new CareerUserControl();
            Career.UpdateUserCredentials(clientCredentials);
            Career.FillData();
        }

        public void OpenStatistics()
        {
            Statistics = new StatisticsUserControl();
            Statistics.UpdateUserCredentials(clientCredentials);
            Statistics.FillData();
        }

        public void OpenQuestionnaire()
        {
            Questionnaire = new QuestionnaireUserControl();
            Questionnaire.UpdateUserCredentials(clientCredentials);
            Questionnaire.FillData();
        }

        public void OpenClients()
        {
            Clients = new ClientsControl();
            Clients.UpdateUserCredentials(clientCredentials);
            Clients.FillData();
        }
    }
}
