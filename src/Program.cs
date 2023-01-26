using Terminal.Gui;
using BBS.Page;

namespace BBS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            Application.QuitKey = Key.Null;

            Application.Run(new Login());

            Application.Shutdown();

            /*using (BBSContext db = new BBSContext())
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
