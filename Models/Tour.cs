namespace Journey.Models
{
    /// <summary>
    /// Класс тура
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Локация где проходит тур
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Количество ночей
        /// </summary>
        public int NightCount { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        public int CostPerVacationer { get; set; }

        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        public int VacotionerCount { get; set; }

        /// <summary>
        /// Наличия Wi-Fi на месте отдыха
        /// </summary>
        public bool WiFiAvailabble { get; set; }

        /// <summary>
        /// Доплата
        /// </summary>
        public decimal Surcharge { get; set; }

        /// <summary>
        /// Цена за одну ночь
        /// </summary>
        public decimal PricePerNight
        {
            get
            {
                if (NightCount == 0)
                {
                    return 0;
                }

                return TotalPrice / NightCount;
            }
        }

        /// <summary>
        /// Итоговая ценна тура
        /// </summary>
        public decimal TotalPrice => CostPerVacationer * VacotionerCount * NightCount + Surcharge;

    }
}

