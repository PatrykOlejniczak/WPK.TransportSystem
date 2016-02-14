using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingSystem.Interface
{
    interface IScheduleProvider
    {
        List<Schedule> GetAllLines();
        Schedule GetScheduleById(int scheduleId);
        Schedule SearchScheduleByLine(string line);

        void AddNewSchedule();
        void EditSchedule(int scheduleId);

    }
}
