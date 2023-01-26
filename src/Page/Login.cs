namespace BBS.Page
{
    using System.Security.Cryptography;
    using System.Text;
    using Terminal.Gui;

    public class Login : Page
    {
        TextField username;
        TextField password;

        Label unameLabel;
        Label passwdLabel;

        Button loginButton;
        Button exitButton;

        LineView unameLine;
        LineView passwdLine;

        ColorScheme inputScheme;

        private void InitViews()
        {
            username = new TextField("")
            {
                X = Pos.Center() - 5,
                Y = 1,
                Width = 20,
                Height = 1,
                TextAlignment = TextAlignment.Left,
                ColorScheme = inputScheme,
            };

            password = new TextField("")
            {
                X = Pos.Center() - 5,
                Y = 3,
                Width = 20,
                Height = 1,
                TextAlignment = TextAlignment.Left,
                ColorScheme = inputScheme,
                Secret = true,
            };

            unameLabel = new Label("username:")
            {
                X = Pos.Center() - 15,
                Y = 1,
            };

            passwdLabel = new Label("password:")
            {
                X = Pos.Center() - 15,
                Y = 3,
            };

            loginButton = new Button("Login")
            {
                X = Pos.Center() - 5,
                Y = 5,
                ColorScheme = buttonScheme,
            };

            exitButton = new Button("Exit")
            {
                X = Pos.Center() + 5,
                Y = 5,
                ColorScheme = buttonScheme,
            };

            unameLine = new LineView()
            {
                X = Pos.Center() - 5,
                Y = 2,
                Width = 20,
                LineRune = '‾',
            };

            passwdLine = new LineView()
            {
                X = Pos.Center() - 5,
                Y = 4,
                Width = 20,
                LineRune = '‾',
            };

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

        public Login()
        {
            inputScheme = new ColorScheme()
            {
                Normal = new Attribute(Color.White, Color.Black),
                HotNormal = new Attribute(Color.White, Color.Black),
                Focus = new Attribute(Color.White, Color.Black),
                HotFocus = new Attribute(Color.White, Color.Black),
            };

            InitViews();

            exitButton.Clicked += () =>
            {
                Application.Shutdown();
                System.Environment.Exit(0);
            };

            loginButton.Clicked += () =>
            {
                if (username.Text.Length < 3 || username.Text.Length > 32)
                {
                    MessageBox.Query(40, 6, "",
                    "username must be between 3 and 32 characters", "OK");
                    return;
                }

                if (password.Text.Length < 8)
                {
                    MessageBox.Query(40, 6, "",
                    "password must be at least 8 characters long", "OK");
                    return;
                }

                Entity.User user = null;
                try
                {
                    user = BBSContext.Context.User
                    .Where(user => user.Username == ((string)username.Text))
                    .First();
                }
                catch
                {
                }

                if (user == null)
                {
                    int sel = MessageBox.Query(40, 6, "",
                    String.Format("There doesn't seem to be such a user\nCreate it?", username.Text),
                    "Yes", "No");

                    if (sel == 1)
                    {
                        return;
                    }

                    BBSContext.Context.User.Add(new Entity.User()
                    {
                        Username = (string)username.Text,
                        PasswordHash = sha256((string)password.Text),
                        Joined = DateTime.Now,
                    });

                    BBSContext.Context.SaveChanges();
                }
            };
        }
    }
}
