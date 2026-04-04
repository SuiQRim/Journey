using Journey.Applications.JourneyWinforms.UI.Formatter;
using Journey.Models;
using Journey.Services.Contracts;

namespace Journey.Applications.JourneyWinforms.UI.Renders
{
    /// <summary>
    /// Класс отображения визуальных элементов
    /// </summary>
    public static class TourGridRenderer
    {
        private const int VerticalPadding = 2;
        private const double MidPoint = 0.5;
        private const double GradientScale = 2.0;

        /// <summary>
        /// Отображение итоговой цены
        /// </summary>
        /// <param name="e">Таблица</param>
        /// <param name="tour">туры</param>
        /// <param name="data">список туров</param>
        /// <param name="service">сервис туров</param>
        public static void PaintTotalPrice(
            DataGridViewCellPaintingEventArgs e,
            Tour tour,
            IEnumerable<Tour> data,
            ITourService service)
        {
            e.PaintBackground(e.CellBounds, true);

            var percent = service.GetNormalizedPrice(data, tour);
            var barWidth = (int)(e.CellBounds.Width * (double)percent);

            var color = GetGradientColor((double)percent);

            using var brush = new SolidBrush(color);

            var rect = new Rectangle(
                e.CellBounds.X,
                e.CellBounds.Y + VerticalPadding,
                barWidth,
                e.CellBounds.Height - VerticalPadding * 2
            );

            e.Graphics.FillRectangle(brush, rect);

            var price = service.GetTotalPrice(tour);
            var text = TourFormatter.FormatMoney(price);

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
            return percent < MidPoint
                ? Interpolate(Color.Green, Color.Cyan, percent * GradientScale)
                : Interpolate(Color.Cyan, Color.MediumPurple, (percent - MidPoint) * GradientScale);
        }

        private static Color Interpolate(Color start, Color end, double ratio)
        {
            return Color.FromArgb(
                (int)(start.R + (end.R - start.R) * ratio),
                (int)(start.G + (end.G - start.G) * ratio),
                (int)(start.B + (end.B - start.B) * ratio)
            );
        }
    }
}
