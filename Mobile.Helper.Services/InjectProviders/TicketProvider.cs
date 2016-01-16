using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.Helper.Services.TicketService;
using Mobile.ViewModel.Helpers;
using Ticket = Mobile.Model.Ticket;

namespace Mobile.Helper.Services.InjectProviders
{
    public class TicketProvider : ITicketProvider
    {
        private readonly TicketServiceClient _client;

        public TicketProvider()
        {
            _client = new TicketServiceConfiguration().TicketServiceClient;
        }

        public async Task<ObservableCollection<Ticket>> GetAllAsync()
        {
            var f = await _client.GetAllAsync();

            AutoMapper.Mapper.CreateMap<TicketService.Ticket, Ticket>();
            AutoMapper.Mapper.CreateMap<Ticket, TicketService.Ticket>();
            var converted = AutoMapper.Mapper.Map<IEnumerable<Ticket>>(f);

            return new ObservableCollection<Ticket>(converted);
        }
    }
}