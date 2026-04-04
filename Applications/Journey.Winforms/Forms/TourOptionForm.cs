using Journey.Applications.JourneyWinforms.Extensions;
using Journey.Models;

namespace Journey.Applications.JourneyWinforms.Forms
{
    /// <summary>
    /// Класс формы добавления и редактирования тура
    /// </summary>
    public partial class TourOptionForm : Form
    {

        private Tour tour;

        /// <summary>
        /// Результат формы
        /// </summary>
        public Tour? ResultTour { get; private set; }

        /// <summary>
        /// ctor для добавления
        /// </summary>
        public TourOptionForm()
        {
            InitializeComponent();

            tour = new Tour
            {
                DepartureDate = DateTime.Now,
                NightCount = 1,
                VacationerCount = 1
            };

            InitBindings();
        }

        /// <summary>
        /// ctor для редактирования
        /// </summary>
        public TourOptionForm(Tour existingTour)
        {
            InitializeComponent();

            tour = new Tour
            {
                Id = existingTour.Id,
                Location = existingTour.Location,
                NightCount = existingTour.NightCount,
                DepartureDate = existingTour.DepartureDate,
                CostPerVacationer = existingTour.CostPerVacationer,
                VacationerCount = existingTour.VacationerCount,
                WiFiAvailabble = existingTour.WiFiAvailabble,
                Surcharge = existingTour.Surcharge
            };

            InitBindings();

            FormNameLabel.Text = "Редактирование тура";
            AcceptAddButton.Text = "Сохранить";
        }

        /// <summary>
        /// Инициализация биндингов
        /// </summary>
        private void InitBindings()
        {
            LocationTextBox.AddBinding(x => x.Text, tour, x => x.Location, TourErrorProvider);
            NightCountNUpDown.AddBinding(x => x.Value, tour, x => x.NightCount, TourErrorProvider);
            DepartureDateTimePicker.AddBinding(x => x.Value, tour, x => x.DepartureDate, TourErrorProvider);
            CostPerVacationerNUpDown.AddBinding(x => x.Value, tour, x => x.CostPerVacationer, TourErrorProvider);
            VacotionerCountNUpDown.AddBinding(x => x.Value, tour, x => x.VacationerCount, TourErrorProvider);
            WiFiAvailableCheckBox.AddBinding(x => x.Checked, tour, x => x.WiFiAvailabble, TourErrorProvider);
            SurchargeNUpDown.AddBinding(x => x.Value, tour, x => x.Surcharge, TourErrorProvider);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            ResultTour = tour;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
