using Terminal.Gui;
using Beta3.Page;

namespace Beta3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            Application.QuitKey = Key.Null;

            Application.Run<Login>();

            Application.Shutdown();

            /*using (BBSContext db = new Beta3Context())
            {
                User user = new User { Username = "sysop", PasswordHash = "password", Joined = DateTime.Now };

                db.User.Add(user);
                db.SaveChanges();

                Message message = new Message { Sender = user, Receiver = user, Content = "ahoj", Sent = DateTime.Now };

                db.Message.Add(message);
                db.SaveChanges();
            }*/
        }
    }
}
