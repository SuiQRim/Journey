using System.ComponentModel;
using System.Globalization;
using Journey.Models;
using Journey.Storage;

namespace Journey.Applications.ToursWinforms
{
    /// <summary>
    /// Главная форма о туре
    /// </summary>
    public partial class TourForm : Form
    {

        private readonly ToursStorage toursStorage;

        /// <summary>
        /// ctor
        /// </summary>
        public TourForm(ToursStorage toursStorage)
        {
            InitializeComponent();
            this.toursStorage = toursStorage;
            ToursDataViewGrid.AutoGenerateColumns = false;

            LoadData();
        }

        private void LoadData()
        {
            var tours = new BindingList<Tour>(toursStorage.Tours);

            ToursDataViewGrid.DataSource = tours;
            ToursDataViewGrid.AutoResizeColumns();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var column = ToursDataViewGrid.Columns[e.ColumnIndex];

            if (column.Name == DepartureDate.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = tour.DepartureDate.ToString("dd MMMM yyyy", new CultureInfo("ru-RU"));
                }
            }

            if (column.Name == WiFiAvailable.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = tour.WiFiAvailabble ? "Да" : "Нет";
                }
            }

            if (column.Name == TotalPrice.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = tour.TotalPrice.ToString("N0", new CultureInfo("ru-RU")) + " ₽";
                }
            }

            if (column.Name == PricePerNight.Name)
            {
                if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is Tour tour)
                {
                    e.Value = tour.PricePerNight.ToString("N0", new CultureInfo("ru-RU")) + " ₽";
                }
            }
        }

        private void ToursDataViewGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var columnName = ToursDataViewGrid.Columns[e.ColumnIndex].Name;

            if (columnName == TotalPrice.Name)
            {
                PaintTotalPrice(e);
            }
        }

        private void PaintTotalPrice(DataGridViewCellPaintingEventArgs e)
        {
            if (ToursDataViewGrid.Rows[e.RowIndex].DataBoundItem is not Tour tour)
            {
                return;
            }

            if (ToursDataViewGrid.DataSource is not IEnumerable<Tour> data || !data.Any())
            {
                return;
            }

            var total = tour.TotalPrice;

            var min = data.Min(t => t.TotalPrice);
            var max = data.Max(t => t.TotalPrice);

            var percent = max == min ? 1m : (total - min) / (max - min);

            e.PaintBackground(e.CellBounds, true);

            var barWidth = (int)(e.CellBounds.Width * (double)percent);

            Color color = GetGradientColor((double)percent);

            using (var brush = new SolidBrush(color))
            {
                var rect = new Rectangle(
                    e.CellBounds.X,
                    e.CellBounds.Y + 2,
                    barWidth,
                    e.CellBounds.Height - 4
                );

                e.Graphics.FillRectangle(brush, rect);
            }

            var text = total.ToString("N0", new CultureInfo("ru-RU")) + " ₽";

            TextRenderer.DrawText(
                e.Graphics,
                text,
                e.CellStyle.Font,
                e.CellBounds,
                Color.Black,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter
            );

            e.Handled = true;
        }

        private static Color GetGradientColor(double percent)
        {
            if (percent < 0.5)
            {
                return Interpolate(Color.Green, Color.Cyan, percent * 2);
            }
            else
            {
                return Interpolate(Color.Cyan, Color.MediumPurple, (percent - 0.5) * 2);
            }
        }

        private static Color Interpolate(Color startColor, Color endColor, double ratio)
        {
            var r = (int)(startColor.R + (endColor.R - startColor.R) * ratio);
            var g = (int)(startColor.G + (endColor.G - startColor.G) * ratio);
            var b = (int)(startColor.B + (endColor.B - startColor.B) * ratio);

            return Color.FromArgb(r, g, b);
        }
    }
}
