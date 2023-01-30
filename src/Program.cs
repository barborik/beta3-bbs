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
        }
    }
}
