namespace Journey.Models
{
    /// <summary>
    /// Класс, представляющий агрегированную статистику по коллекции туров
    /// </summary>
    public class TourStatistics
    {
        /// <summary>
        /// Среднее количество отдыхающих в туре
        /// </summary>
        public double AvgVacationers { get; set; }

        /// <summary>
        /// Процент туров, в которых доступен Wi-Fi
        /// </summary>
        public double WifiPercent { get; set; }

        /// <summary>
        /// Средний процент доплаты относительно общей стоимости тура
        /// </summary>
        public double AvgSurchargePercent { get; set; }

        /// <summary>
        /// Общее количество туров
        /// </summary>
        public int TotalTours { get; set; }

        /// <summary>
        /// Максимальная стоимость тура
        /// </summary>
        public decimal MaxTourPrice { get; set; }

        /// <summary>
        /// Среднее количество ночей в турах
        /// </summary>
        public double AvgNights { get; set; }

        /// <summary>
        /// Процент туров, где есть доплата
        /// </summary>
        public double SurchargeShare { get; set; }
    }
}
