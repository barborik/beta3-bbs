using Terminal.Gui;

namespace Beta3.Page
{
    public partial class UserList : Page
    {
        private View prev;
        private View next;
        private View users;

        private int page = 0, width, height, perPage;

        private string UsersListString()
        {
            string text = "";

            width = 0;
            height = 0;

            perPage = Application.Top.Bounds.Bottom - 8;

            for (int i = 0; i < perPage; i++)
            {
                Entity.User user;
                try
                {
                    user = Beta3Context.Context.User.ToList()[page * perPage + i];
                }
                catch
                {
                    continue;
                }

                string listing = String.Format("{0}\n", user.Username);
                text += listing;

                if (listing.Length > width)
                {
                    width = listing.Length;
                }
                height++;
            }

            return text;
        }

        private void InitViews()
        {
            prev = new View()
            {
                X = Pos.Center(),
                Y = Pos.Top(this),
                Width = 16,
                Height = 2,
                Text = "↑\n[Page Up]",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            next = new View()
            {
                X = Pos.Center(),
                Y = Pos.Bottom(this) - 4,
                Width = 16,
                Height = 2,
                Text = "[Page Down]\n↓",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            users = new View()
            {
                Y = Pos.Center(),
                TextAlignment = TextAlignment.Left,
                CanFocus = true,
                ColorScheme = whiteOnBlack,
            };
            users.Text = UsersListString();
            users.X = Pos.Center() - width / 2;
            users.Width = width;
            users.Height = height;

            this.Add(next);
            this.Add(prev);
            this.Add(users);
        }
    }
}
