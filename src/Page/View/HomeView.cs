using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Home : Page
    {
        View motd;
        View columnLeft;
        View columnRight;
        View menu;

        private void InitViews()
        {
            string column =
                "___________\n" +
                " (       ) \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                "  | | | |  \n" +
                " (_______) \n";

            columnLeft = new View()
            {
                Text = column,
                X = Pos.Center() - 32,
                Y = Pos.Center() - 10,
                Width = 12,
                Height = Dim.Fill(),
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.BrightYellow, Color.Black),
                },
                TextAlignment = TextAlignment.Centered,
            };

            columnRight = new View()
            {
                Text = column,
                X = Pos.Center() + 20,
                Y = Pos.Center() - 10,
                Width = 12,
                Height = Dim.Fill(),
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.BrightYellow, Color.Black),
                },
                TextAlignment = TextAlignment.Centered,
            };

            motd = new View()
            {
                X = Pos.Center(),
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
                Text = Config.GetValue("motd"),
            };

            menu = new View()
            {
                Text = "\n   [1] Boards\n   [2] Messages\n   [3] Users List\n   [4] Log Out\n",
                X = Pos.Center(),
                Y = Pos.Center() - 5,
                Width = 20,
                Height = 6,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.BrightBlue, Color.Black),
                    HotNormal = new Terminal.Gui.Attribute(Color.Red, Color.Black),
                },
                TextAlignment = TextAlignment.Left,
                Border = new Border()
                {
                    Title = "Main Menu",
                    BorderStyle = BorderStyle.Rounded,
                    BorderBrush = Color.DarkGray,
                    Padding = new Thickness(4),
                },
            };

            View select1 = new View()
            {
                Text = "1",
                X = Pos.Center() - 6,
                Y = Pos.Center() - 4,
                Width = 1,
                Height = 1,
                ColorScheme = redOnBlack,
            };

            View select2 = new View()
            {
                Text = "2",
                X = Pos.Center() - 6,
                Y = Pos.Center() - 3,
                Width = 1,
                Height = 1,
                ColorScheme = redOnBlack,
            };

            View select3 = new View()
            {
                Text = "3",
                X = Pos.Center() - 6,
                Y = Pos.Center() - 2,
                Width = 1,
                Height = 1,
                ColorScheme = redOnBlack,
            };

            View select4 = new View()
            {
                Text = "4",
                X = Pos.Center() - 6,
                Y = Pos.Center() - 1,
                Width = 1,
                Height = 1,
                ColorScheme = redOnBlack,
            };

            this.Add(motd);

            this.Add(columnLeft);
            this.Add(columnRight);

            this.Add(menu);

            this.Add(select1);
            this.Add(select2);
            this.Add(select3);
            this.Add(select4);
        }
    }
}
