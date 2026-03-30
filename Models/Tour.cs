using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Укажите локацию")]
        [StringLength(100, ErrorMessage = "Локация не должна превышать 100 символов")]
        public string Location { get; set; }

        /// <summary>
        /// Количество ночей
        /// </summary>
        [Range(1, 365, ErrorMessage = "Количество ночей должно быть от 1 до 30")]
        public int NightCount { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        [Required(ErrorMessage = "Укажите дату вылета")]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Стоимость за одного отдыхающего
        /// </summary>
        [Range(1, 1_000_000, ErrorMessage = "Стоимость должна быть больше 0")]
        public int CostPerVacationer { get; set; }

        /// <summary>
        /// Количество отдыхающих
        /// </summary>
        [Range(1, 5, ErrorMessage = "Количество отдыхающих не должно превышать 5")]
        public int VacotionerCount { get; set; }

        /// <summary>
        /// Наличия Wi-Fi на месте отдыха
        /// </summary>
        public bool WiFiAvailabble { get; set; }

        /// <summary>
        /// Доплата
        /// </summary>
        [Range(0, 1_000_000, ErrorMessage = "Доплата не может быть отрицательной")]
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
        /// Итоговая цена тура
        /// </summary>
        public decimal TotalPrice =>
            CostPerVacationer * VacotionerCount * NightCount + Surcharge;
    }
}
