using System;
using System.Collections.Generic;

namespace ManagingSystem.Interface
{
    public class Schedule : IScheduleProvider
    {
        public void AddNewSchedule()
        {
            throw new NotImplementedException();
        }

        public void EditSchedule(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public List<Schedule> GetAllLines()
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleById(int scheduleId)
        {
            throw new NotImplementedException();
        }

        public Schedule SearchScheduleByLine(string line)
        {
            throw new NotImplementedException();
        }
    }
}