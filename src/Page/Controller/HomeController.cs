using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Home : Page
    {
        private void InitControllers()
        {
            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                switch (EventArgs.KeyEvent.Key)
                {
                    case Key.D1:
                        Application.Run(new BoardsList());
                        break;
                    case Key.D2:
                        Application.Run(new MessagesList());
                        break;
                    case Key.D3:
                        Application.Run(new UserList());
                        break;
                    case Key.D4:
                        Application.Run(new Bookmarks());
                        break;
                    case Key.D5:
                        this.RequestStop();
                        break;
                    case Key.X:
                        if (user.Username == "sysop")
                        {
                            Application.Run(new SysopMenu());
                        }
                        break;
                }
            };
        }
    }
}
