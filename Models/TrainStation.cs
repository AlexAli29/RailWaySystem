namespace TrainTickets.Models
{
    public class TrainStation
    {
        public int ID { get; set; }
        public int TrainID { get; set; }
        public int StationID { get; set; }
        public int Ordinal { get; set; }
        public DateTime ArrivalAt { get; set; }
        public DateTime DepartureAt { get; set; }
        
        public Train Train { get; set; }
        public Station Station { get; set; }
    }
}
