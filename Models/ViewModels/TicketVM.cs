namespace TrainTickets.Models.ViewModels {
    public class TicketVM {
        public int TicketOrdinal { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TrainName { get; set; }
        public string OriginStation { get; set; }
        public string DestStation { get; set; }
        public DateTime DepartDatetime { get; set; }
        public DateTime ArrivalDatetime { get; set; }
        public string TripDuration { get; set; }
        public int CoachNumber { get; set; }
        public int PlaceNumber { get; set; }
        public string CoachType { get; set; }
        public int PriceTenge { get; set; }
    }
}
