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
                        break;
                    case Key.D3:
                        break;
                    case Key.D4:
                        this.RequestStop();
                        break;
                }
            };
        }
    }
}
