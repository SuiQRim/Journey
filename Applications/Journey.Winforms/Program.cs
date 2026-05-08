using Journey.Applications.JourneyWinforms.Forms;
using Journey.Services;
using Journey.Storage.InMemory;
using Serilog;
using Serilog.Extensions.Logging;

namespace Journey.Applications.ToursWinforms
{
    /// <summary>
    /// Класс с точкой входа
    /// </summary>
    static internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithProperty(
                    "Application",
                    typeof(Program).Assembly.GetName().Name)
                .MinimumLevel.Debug()
                .WriteTo.File(
                    "logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {SourceContext} {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            var microsoftLogger = new SerilogLoggerFactory(logger)
                .CreateLogger(typeof(Program).FullName!);

            var toursRepository = new ToursRepository();
            var toursService = new ToursService(toursRepository);
            var toursServiceLogWrapper = new ToursServiceLogWrapper(toursService, microsoftLogger);

            ApplicationConfiguration.Initialize();
            Application.Run(new TourForm(toursServiceLogWrapper));
        }
    }
}
