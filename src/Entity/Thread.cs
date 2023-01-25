namespace BBS.Entity
{
    public class Thread
    {
        public int ID { get; set; }
        public int BoardID { get; set; }
        public string Title { get; set; }

        public Board Board { get; set; }
    }
}
