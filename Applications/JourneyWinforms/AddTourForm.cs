using Journey.Models;

namespace JourneyWinforms
{
    /// <summary>
    /// Класс формы добавления тура
    /// </summary>
    public partial class AddTourForm : Form
    {
        /// <summary>
        /// Результат формы
        /// </summary>
        public Tour ResultTour { get; private set; }

        private Tour tour;

        /// <summary>
        /// ctor
        /// </summary>
        public AddTourForm()
        {
            InitializeComponent();

            tour = new Tour
            {
                DepartureDate = DateTime.Now,
                NightCount = 1,
                VacotionerCount = 1
            };

            LocationTextBox.DataBindings.Add("Text", tour, nameof(Tour.Location));
            NightCountNUpDown.DataBindings.Add("Value", tour, nameof(Tour.NightCount));
            DepartureDateTimePicker.DataBindings.Add("Value", tour, nameof(Tour.DepartureDate));
            CostPerVacationerNUpDown.DataBindings.Add("Value", tour, nameof(Tour.CostPerVacationer));
            VacotionerCountNUpDown.DataBindings.Add("Value", tour, nameof(Tour.VacotionerCount));
            WiFiAvailableCheckBox.DataBindings.Add("Checked", tour, nameof(Tour.WiFiAvailabble));
            SurchargeNUpDown.DataBindings.Add("Value", tour, nameof(Tour.Surcharge));
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            ResultTour = tour;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
