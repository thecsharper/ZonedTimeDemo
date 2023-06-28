using Microsoft.Extensions.Logging;

using NodaTime.Text;
using NodaTime;

namespace ZonedTimeDemo
{
    public class ZonedDemo
    {
        private readonly DateTimeZone _zone;
        private readonly IClock _clock;
        private readonly ILogger _logger;

        public ZonedDemo(DateTimeZone zone, IClock clock, ILogger logger)
        {
            _zone = zone;
            _clock = clock;
            _logger = logger;
        }

        public void MainLoop(TimeSpan pollingInterval)
        {
            while (true)
            {
                var now = _clock.GetCurrentInstant();

                var nowInTimeZone = now.InZone(_zone);

                _logger.LogInformation("At {now} ({local} local)",
                    InstantPattern.ExtendedIso.Format(now),
                    ZonedDateTimePattern.GeneralFormatOnlyIso.Format(nowInTimeZone));

                Thread.Sleep(pollingInterval);
            }
        }
    }

}
