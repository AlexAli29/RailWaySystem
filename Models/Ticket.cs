namespace TrainTickets.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int OriginTrainStationID { get; set; }
        public int DestTrainStationID { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }

        public TrainStation OriginTrainStation { get; set; }
        public TrainStation DestTrainStation { get; set; }
    }
}
