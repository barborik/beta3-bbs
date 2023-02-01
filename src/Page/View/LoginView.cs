using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Login : Page
    {
        private View text;

        private TextField username;
        private TextField password;

        private Label unameLabel;
        private Label passwdLabel;

        private Button loginButton;
        private Button exitButton;

        private LineView unameLine;
        private LineView passwdLine;

        private void InitViews()
        {
            text = new Terminal.Gui.View()
            {
                Text =
                "██████╗ ███████╗████████╗ █████╗ ██████╗       ██████╗ ██████╗ ███████╗\n" +
                "██╔══██╗██╔════╝╚══██╔══╝██╔══██╗╚════██╗      ██╔══██╗██╔══██╗██╔════╝\n" +
                "██████╔╝█████╗     ██║   ███████║ █████╔╝█████╗██████╔╝██████╔╝███████╗\n" +
                "██╔══██╗██╔══╝     ██║   ██╔══██║ ╚═══██╗╚════╝██╔══██╗██╔══██╗╚════██║\n" +
                "██████╔╝███████╗   ██║   ██║  ██║██████╔╝      ██████╔╝██████╔╝███████║\n" +
                "╚═════╝ ╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═════╝       ╚═════╝ ╚═════╝ ╚══════╝\n",

                X = Pos.Center(),
                Y = 1,
                Width = Dim.Fill(),
                Height = 8,
                TextAlignment = TextAlignment.Centered,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.DarkGray, Color.Black),
                },
            };

            username = new TextField("")
            {
                X = Pos.Center() - 8,
                Y = 10,
                Width = 20,
                Height = 1,
                TextAlignment = TextAlignment.Left,
                ColorScheme = whiteOnBlack,
            };

            password = new TextField("")
            {
                X = Pos.Center() - 8,
                Y = 12,
                Width = 20,
                Height = 1,
                TextAlignment = TextAlignment.Left,
                ColorScheme = whiteOnBlack,
                Secret = true,
            };

            unameLabel = new Label("username:")
            {
                X = Pos.Center() - 18,
                Y = 10,
                ColorScheme = whiteOnBlack,
            };

            passwdLabel = new Label("password:")
            {
                X = Pos.Center() - 18,
                Y = 12,
                ColorScheme = whiteOnBlack,
            };

            loginButton = new Button("Login")
            {
                X = Pos.Center() - 8,
                Y = 14,
                ColorScheme = buttonScheme,
            };

            exitButton = new Button("Exit")
            {
                X = Pos.Center() + 2,
                Y = 14,
                ColorScheme = buttonScheme,
            };

            unameLine = new LineView()
            {
                X = Pos.Center() - 8,
                Y = 11,
                Width = 20,
                LineRune = '‾',
                ColorScheme = whiteOnBlack,
            };

            passwdLine = new LineView()
            {
                X = Pos.Center() - 8,
                Y = 13,
                Width = 20,
                LineRune = '‾',
                ColorScheme = whiteOnBlack,
            };

            this.Add(text);

            this.Add(username);
            this.Add(password);

            this.Add(unameLabel);
            this.Add(passwdLabel);

            this.Add(loginButton);
            this.Add(exitButton);

            this.Add(unameLine);
            this.Add(passwdLine);
        }
    }
}
