namespace Journey.Models
{
    public class Tour
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public int NightCount { get; set; }

        public DateTime DepartureDate { get; set; }

        public int CostPerVacationer { get; set; }

        public int VacotionerCount { get; set; }

        public int WiFiAvailabble { get; set; }

        public decimal Surcharge { get; set; }

    }
}

