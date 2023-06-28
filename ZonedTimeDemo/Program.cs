using ZonedTimeDemo;

using NodaTime;
using NodaTime.Extensions;
using Microsoft.Extensions.Logging;

var zone = DateTimeZoneProviders.Tzdb["Europe/London"];

var clock = SystemClock.Instance.InZone(zone);

using ILoggerFactory loggerFactory =
    LoggerFactory.Create(builder =>
        builder.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        }));

var logger = loggerFactory.CreateLogger<Program>();

var demo = new ZonedDemo(zone, clock, logger);

demo.MainLoop(TimeSpan.FromMilliseconds(1000));