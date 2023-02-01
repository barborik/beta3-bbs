using Terminal.Gui;
using Beta3.Page;

namespace Beta3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            Application.Run(new Board(new Entity.Board()));
            Application.Shutdown();
            return;
            /*Application.Init();
            Application.Run(new Boards());
            Application.Shutdown();
            return;*/
            /*Application.Init();
            Application.Run(new Home(new Entity.User()));
            Application.Shutdown();
            return;*/

            try
            {
                Beta3Context.Context.Database.CanConnect();
            }
            catch
            {
                Console.WriteLine("server is momentarily down, please try again later");
                System.Environment.Exit(0);
            }

            Application.Init();
            Application.QuitKey = Key.Null;

            Application.Run<Login>();

            Application.Shutdown();
        }
    }
}
