namespace TrainTickets.Models
{
    public class Train
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Coach> Coaches { get; set; }
        public ICollection<TrainStation> TrainStations { get; set; }
    }
}
