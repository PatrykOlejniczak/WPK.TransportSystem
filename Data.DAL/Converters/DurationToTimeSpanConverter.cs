using System;
using AutoMapper;
using Data.Entities;

namespace Data.Core.Converters
{
    public class DurationToTimeSpanConverter : TypeConverter<Duration, TimeSpan>
    {
        protected override TimeSpan ConvertCore(Duration duration)
        {
            return new TimeSpan(duration.Days, duration.Hours, duration.Minutes, 0);
        }
    }
}