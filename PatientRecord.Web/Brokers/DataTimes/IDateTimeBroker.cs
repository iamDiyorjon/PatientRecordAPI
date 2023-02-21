using System;

namespace PatientRecord.Web.Brokers.DataTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTime();
    }
}
