using Journey.Applications.JourneyWinforms.Forms;
using Journey.Services;
using Journey.Storage.InMemory;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var toursRepository = new ToursRepository();
            var toursService = new ToursService(toursRepository);
            Application.Run(new TourForm(toursService));
        }
    }
}
