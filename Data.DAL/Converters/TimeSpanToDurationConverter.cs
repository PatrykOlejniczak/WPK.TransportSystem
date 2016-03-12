using System;
using AutoMapper;
using Data.Entities;

namespace Data.Core.Converters
{
    public class TimeSpanToDurationConverter : TypeConverter<TimeSpan, Duration>
    {
        protected override Duration ConvertCore(TimeSpan timespan)
        {
            return new Duration(timespan.Days, timespan.Hours, timespan.Minutes);
        }
    }
}