using Terminal.Gui;

namespace Beta3.Page
{
    public class Home : Page
    {
        private Entity.User user;

        public Home(Entity.User user)
        {
            this.user = user;

            View text = new View()
            {
                Text = "\n[B]oards | [M]essages | [U]sers List | [L]og Out",
                X = Pos.Center(),
                Y = Pos.Center(),
                Width = Dim.Fill(4),
                Height = 5,
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
                Border = new Border()
                {
                    BorderBrush = Color.White,
                    BorderStyle = BorderStyle.Double,
                },
            };

            this.Add(text);

            KeyDown += (EventArgs) =>
            {
                switch (EventArgs.KeyEvent.Key)
                {
                    case Key.L:
                        this.RequestStop();
                        break;
                }
            };
        }
    }
}
