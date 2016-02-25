using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mobile.Helper.Services.LineService;
using Mobile.Helper.Services.ServiceConfiguration;
using Mobile.ViewModel.Helpers;
using Line = Mobile.Model.Line;

namespace Mobile.Helper.Services.InjectProviders
{
    public class LineProvider : ILineProvider
    {
        private readonly LineServiceClient _client;

        public LineProvider()
        {
            _client = new LineServiceConfiguration().LineServiceClient;
        }

        public async Task<ObservableCollection<Line>> GetAllAsync()
        {
            //var f = await _client.GetAllAsync();

            var f =new ObservableCollection<LineService.Line>()
            {
                new LineService.Line() { Id = 0, IsDeleted = false, Name = "12"},
                new LineService.Line() { Id = 1, IsDeleted = false, Name = "14"},
                new LineService.Line() { Id = 2, IsDeleted = false, Name = "15"},
                new LineService.Line() { Id = 3, IsDeleted = false, Name = "16"},
                new LineService.Line() { Id = 4, IsDeleted = false, Name = "18"}
            };

            AutoMapper.Mapper.CreateMap<LineService.Line, Line>();
            AutoMapper.Mapper.CreateMap<Line, LineService.Line>();
            var converted = AutoMapper.Mapper.Map<IEnumerable<Line>>(f);

            return new ObservableCollection<Line>(converted);
        }
    }
}