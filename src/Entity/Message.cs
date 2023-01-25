namespace BBS.Entity
{
    public class Message
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime Sent { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
