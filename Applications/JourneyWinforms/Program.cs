using Journey.Storage;

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
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ToursStorage toursStorage = new();
            Application.Run(new TourForm(toursStorage));
        }
    }
}
