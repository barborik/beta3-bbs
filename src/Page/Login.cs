using System.Security.Cryptography;
using System.Text;
using Terminal.Gui;

namespace Beta3.Page
{
    public class Login : Page
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
            text = new View()
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

        static string sha256(string str)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LoginButtonController()
        {
            if (username.Text.Length < 3 || username.Text.Length > 32 || !username.Text.All(c => char.IsLetterOrDigit((char)c)))
            {
                MessageBox.ErrorQuery("", "username must be between 3 and 32 alphanumeric characters", "OK");
                return;
            }

            if (password.Text.Length < 8)
            {
                MessageBox.ErrorQuery("", "password must be at least 8 characters long", "OK");
                return;
            }

            Entity.User user = null;
            try
            {
                user = Beta3Context.Context.User
                .Where(user => user.Username == ((string)username.Text))
                .First();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }

            if (user == null)
            {
                int sel = MessageBox.Query("",
                String.Format("There doesn't seem to be such a user\nCreate it?", username.Text),
                "Yes", "No");

                if (sel == 1)
                {
                    return;
                }

                user = new Entity.User()
                {
                    Username = (string)username.Text,
                    PasswordHash = sha256((string)password.Text),
                    Joined = DateTime.Now,
                };

                Beta3Context.Context.User.Add(user);
                Beta3Context.Context.SaveChanges();
            }

            if (user.PasswordHash != sha256((string)password.Text))
            {
                MessageBox.ErrorQuery("", "wrong password", "OK");
                return;
            }

            Application.Run(new Home(user));
        }

        private void ExitButtonController()
        {
            Application.Shutdown();
            System.Environment.Exit(0);
        }

        public Login()
        {
            InitViews();

            exitButton.Clicked += ExitButtonController;
            loginButton.Clicked += LoginButtonController;
        }
    }
}
