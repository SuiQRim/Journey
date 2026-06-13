using System.ComponentModel.DataAnnotations;

namespace Journey.WebAppMVC.Models
{
    /// <summary>
    /// ViewModel для создания и редактирования тура
    /// </summary>
    public class TourUpsertViewModel
    {
        /// <summary>
        /// Идентификатор тура
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Локация
        /// </summary>
        [Required(ErrorMessage = "Локация обязательна")]
        [StringLength(100, ErrorMessage = "Локация не должна превышать 100 символов")]
        public string Location { get; set; }

        /// <summary>
        /// Количество ночей
        /// </summary>
        [Range(1, 365, ErrorMessage = "Количество ночей должно быть от 1 до 365")]
        public int NightCount { get; set; }

        /// <summary>
        /// Дата вылета
        /// </summary>
        [Required(ErrorMessage = "Укажите дату вылета")]
        [DataType(DataType.Date)]
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
        public int VacationerCount { get; set; }

        /// <summary>
        /// Наличие Wi-Fi на месте отдыха
        /// </summary>
        public bool WiFiAvailable { get; set; }

        /// <summary>
        /// Доплата
        /// </summary>
        [Range(0, 1_000_000, ErrorMessage = "Доплата не может быть отрицательной")]
        public decimal Surcharge { get; set; }

        /// <summary>
        /// Признак того, что форма используется для редактирования
        /// существующего тура или создания нового
        /// </summary>
        public bool IsEdit => Id.HasValue;
    }
}
