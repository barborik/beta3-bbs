using System;
using Terminal.Gui;
using BBS.Entity;

namespace BBS
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Application.Init();
            Application.Run(new BBS.Page.Login());
            Application.Shutdown();*/
            // Console.WriteLine("Hello, World!");

            using (BBSContext db = new BBSContext())
            {
                User user = new User { Username = "sysop", PasswordHash = "password", Joined = DateTime.Now };

                db.User.Add(user);
                db.SaveChanges();

                Message message = new Message { Sender = user, Receiver = user, Content = "ahoj", Sent = DateTime.Now };

                db.Message.Add(message);
                db.SaveChanges();
            }
        }
    }
}
