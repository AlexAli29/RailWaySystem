namespace TrainTickets.Models.ViewModels {
    public class StationsAndDateVM {
        public string OriginStation { get; set; }
        public string DestStation { get; set; }
        public DateOnly DepartDate { get; set; }
    }
}
