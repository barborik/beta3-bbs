namespace Beta3.Entity
{
    public class Bookmark
    {
        public int ID { get; set; }
        public int ThreadID { get; set; }
        public int BoardID { get; set; }
        public int UserID { get; set; }

        public Thread Thread { get; set; }
        public Board Board { get; set; }
        public User User { get; set; }
    }
}
