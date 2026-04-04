using System.ComponentModel;
using Journey.Applications.JourneyWinforms.UI;
using Journey.Applications.JourneyWinforms.UI.Formatter;
using Journey.Applications.JourneyWinforms.UI.Renders;
using Journey.Models;
using Journey.Services.Contracts;

namespace Journey.Applications.JourneyWinforms.Forms
{
    /// <summary>
    /// Главная форма о туре
    /// </summary>
    public partial class TourForm : Form
    {
        private readonly ITourService toursService;
        private BindingList<Tour> toursBinding;

        /// <summary>
        /// ctor
        /// </summary>
        public TourForm(ITourService toursService)
        {
            this.toursService = toursService;

            InitializeComponent();

            BindTours();
            LoadData();
            UpdateStatistics(toursBinding);
        }

        private void BindTours()
        {
            toursBinding = [];
            ToursDataViewGrid.AutoGenerateColumns = false;
            ToursDataViewGrid.DataSource = toursBinding;
        }

        private void LoadData()
        {
            toursBinding.Clear();

            foreach (var t in toursService.GetTours())
            {
                toursBinding.Add(t);
            }

            ToursDataViewGrid.AutoResizeColumns();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var column = ToursDataViewGrid.Columns[e.ColumnIndex];

            if (column.Name == DepartureDate.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = TourFormatter.FormatDate(tour.DepartureDate);
                }
            }

            if (column.Name == WiFiAvailable.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = TourFormatter.FormatWifi(tour.WiFiAvailabble);
                }
            }

            if (column.Name == TotalPrice.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    var totalPrice = toursService.GetTotalPrice(tour);
                    e.Value = TourFormatter.FormatMoney(totalPrice);
                }
            }

            if (column.Name == PricePerNight.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    var perNight = toursService.GetPricePerNight(tour);
                    e.Value = TourFormatter.FormatMoney(perNight);
                }
            }

        }

        private void ToursDataViewGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (ToursDataViewGrid.Columns[e.ColumnIndex].Name == TotalPrice.Name &&
                ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour &&
                ToursDataViewGrid.DataSource is IEnumerable<Tour> data)
            {
                TourGridRenderer.PaintTotalPrice(e, tour, data, toursService);
            }
        }

        private void AddTourButton_Click(object sender, EventArgs e)
        {
            using var form = new TourOptionForm();

            if (form.ShowDialog() == DialogResult.OK && form.ResultTour != null)
            {
                var tour = form.ResultTour;

                toursService.AddTour(tour);
                toursBinding.Add(tour);

                UpdateStatistics(toursBinding);
            }
        }

        private void EditTourButton_Click(object sender, EventArgs e)
        {
            var selectedTour = GetSelectedTour();

            if (selectedTour is null)
            {
                MessageBox.Show("Выберите тур для редактирования");
                return;
            }

            using var form = new TourOptionForm(selectedTour);

            if (form.ShowDialog() == DialogResult.OK && form.ResultTour != null)
            {
                var updatedTour = form.ResultTour;
                toursService.UpdateTour(updatedTour);
                var index = toursBinding.ToList()
                    .FindIndex(t => t.Id == updatedTour.Id);

                if (index >= 0)
                {
                    toursBinding[index] = updatedTour;
                    toursBinding.ResetBindings();
                }

                UpdateStatistics(toursBinding);
            }
        }

        private Tour? GetSelectedTour()
        {
            if (ToursDataViewGrid.CurrentRow?.DataBoundItem is Tour tour)
            {
                return tour;
            }

            return null;
        }

        private void UpdateStatistics(IEnumerable<Tour> tours)
        {
            var stats = toursService.CalculateStatistics(tours);

            var hasData = stats.TotalTours > 0;
            ToursStarusStrip.Visible = hasData;
            if (!hasData)
            {
                return;
            }

            AvgVacationersLabel.Text = $"{StatsLabels.AvgVacationers}: {stats.AvgVacationers:0.00}";
            WifiPercentLabel.Text = $"{StatsLabels.WifiPercent}: {stats.WifiPercent:0.0}%";
            SurchargePercentLabel.Text = $"{StatsLabels.SurchargePercent}: {stats.AvgSurchargePercent:0.0}%";
            TotalToursLabel.Text = $"{StatsLabels.TotalTours}: {stats.TotalTours}";
            MaxPriceLabel.Text = $"{StatsLabels.MaxPrice}: {stats.MaxTourPrice:0.00} ₽";
            AvgNightsLabel.Text = $"{StatsLabels.AvgNights}: {stats.AvgNights:0.0}";
            SurchargeShareLabel.Text = $"{StatsLabels.SurchargeShare}: {stats.SurchargeShare:0.0}%";
        }
    }
}
