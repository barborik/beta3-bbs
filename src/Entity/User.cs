namespace Beta3.Entity
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Joined { get; set; }
    }
}
