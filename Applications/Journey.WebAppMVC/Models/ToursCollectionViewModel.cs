using Journey.Models;

namespace Journey.WebAppMVC.Models
{
    public class ToursCollectionViewModel
    {
        public required IEnumerable<Tour> Tours { get; set; }

        public required TourStatistics Statistics { get; set; }

        public required int Page { get; set; }

        public int TotalPages { get; set; }
    }
}
