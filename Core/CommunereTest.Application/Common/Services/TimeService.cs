using System;
using CommunereTest.Domain.Interfaces;

namespace CommunereTest.Application.Common.Services
{
    public class TimeService : ITimeService
    {
        public long GetUnixTimestamp(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
