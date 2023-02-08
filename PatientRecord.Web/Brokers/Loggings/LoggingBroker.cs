using Microsoft.Extensions.Logging;
using System;

namespace PatientRecord.Web.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger)=>
            this.logger = logger;


        public void LogCritical(Exception exception) =>
            logger.LogCritical(exception, exception.Message);

        public void LogError(Exception exception)=>
            logger.LogError(exception, exception.Message);
    }
}
