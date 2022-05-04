namespace TrainTickets.Models
{
    public class Place
    {
        public int ID { get; set; }
        public int CoachID { get; set; }
        public int PlaceNumber { get; set; }
        public string Type { get; set; }
        public bool IsFree { get; set; }
        
        public Coach Coach { get; set; }
    }
}
