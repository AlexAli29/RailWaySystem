namespace TrainTickets.Models
{
    public class Coach
    {
        public int ID { get; set; }
        public int TrainID { get; set; }
        public int CoachNumber { get; set; }
        public string Type { get; set; }
        public int PriceTenge { get; set; }
    
        public Train Train { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
