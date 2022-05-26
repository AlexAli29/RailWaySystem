namespace TrainTickets.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int PlaceID { get; set; }
        public int OriginTrainStationID { get; set; }
        public int DestTrainStationID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public Place Place { get; set; }

        public TrainStation OriginTrainStation { get; set; }
        public TrainStation DestTrainStation { get; set; }
    }
}
