using System.ComponentModel.DataAnnotations;

namespace Journey.WebAppMVC.Models
{
    public class TourUpsertViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Локация обязательна")]
        [StringLength(100)]
        public string Location { get; set; }

        [Range(1, 365)]
        public int NightCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Range(0, 100000)]
        public int CostPerVacationer { get; set; }

        [Range(1, 100)]
        public int VacationerCount { get; set; }

        public bool WiFiAvailable { get; set; }

        [Range(0, 50000)]
        public decimal Surcharge { get; set; }

        public bool IsEdit => Id.HasValue;
    }
}
