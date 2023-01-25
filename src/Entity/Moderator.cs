namespace BBS.Entity
{
    public class Moderator
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BoardID { get; set; }

        public User User { get; set; }
        public Board Board { get; set; }
    }
}
