namespace BBS.Entity
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ThreadID { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

        public User User { get; set; }
        public Thread Thread { get; set; }
    }
}
