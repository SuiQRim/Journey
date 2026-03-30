using System.Globalization;

namespace Journey.Applications.JourneyWinforms.UI.Formatter
{
    public static class TourFormatter
    {
        private const string Currency = "₽";
        private readonly static CultureInfo ru = new("ru-RU");

        /// <summary>
        /// Форматирует дату
        /// </summary>
        /// <param name="date">дата</param>
        /// <returns>Отформатированная строка</returns>
        public static string FormatDate(DateTime date) => date.ToString("dd MMMM yyyy", ru);

        /// <summary>
        /// Форматирует в денюжный формат
        /// </summary>
        /// <param name="value">Сумма</param>
        /// <returns>Отформатированная строка</returns>
        public static string FormatMoney(decimal value) => value.ToString("N0", ru) + Currency.PadLeft(2, ' ');

        /// <summary>
        /// Форматирует статус Wi-Fi
        /// </summary>
        /// <param name="isAvailable">доступен ли Wi-Fi</param>
        /// <returns>Отформатированная строка</returns>
        public static string FormatWifi(bool isAvailable) => isAvailable ? "Да" : "Нет";
    }
}
