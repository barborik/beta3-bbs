using System.Security.Cryptography;
using System.Text;
using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Login : Page
    {
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
            if (!this.IsCurrentTop)
            {
                return;
            }

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
                //Console.WriteLine("ERROR: " + e.Message);
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

            try
            {
                if (Beta3Context.Context.Ban.Any(b => b.UserID == user.ID && b.End > DateTime.Now))
                {
                    MessageBox.ErrorQuery("", "you have been banned", "OK");
                    return;
                }
            }
            catch { }

            Application.Run(new Home(user));
        }

        private void ExitButtonController()
        {
            if (!this.IsCurrentTop)
            {
                return;
            }

            Application.Shutdown();
            System.Environment.Exit(0);
        }

        private void InitControllers()
        {
            exitButton.Clicked += ExitButtonController;
            loginButton.Clicked += LoginButtonController;
        }
    }
}
