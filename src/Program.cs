using System;
using Terminal.Gui;

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
            }
        }
    }
}
