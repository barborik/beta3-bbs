namespace Beta3.Entity
{
    public class Ban
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Reason { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public User User { get; set; }
    }
}
