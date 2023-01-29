using Terminal.Gui;

namespace Beta3.Page
{
    public class Home : Page
    {
        private int g;

        public Home(Entity.User user)
        {
            Application.RequestStop();

            KeyDown += (EventArgs) =>
            {
                switch (EventArgs.KeyEvent.Key)
                {
                    case Key.Q:
                        Application.Top.Remove(this);
                        break;
                }
            };
        }
    }
}