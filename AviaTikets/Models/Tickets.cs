using System.ComponentModel.DataAnnotations;

namespace AviaTikets.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string StartAirport { get; set; }
        public string EndAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string ClassSeat { get; set; }

    }
}
