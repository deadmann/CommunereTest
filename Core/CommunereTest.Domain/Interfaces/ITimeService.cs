using System;

namespace CommunereTest.Domain.Interfaces
{
    public interface ITimeService
    {
        long GetUnixTimestamp(DateTime dateTime);
    }
}
