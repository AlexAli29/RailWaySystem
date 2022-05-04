using System.ComponentModel.DataAnnotations;

namespace TrainTickets.Models.ViewModels {
    public class TrainVM {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public DateOnly DepartDate { get; set; }
        public TimeOnly DepartTime { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public TimeOnly ArrivalTime { get; set; }
        public string TripDuration { get; set; }
        public int MinPriceTenge { get; set; }
    }
}
