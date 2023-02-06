using Terminal.Gui;

namespace Beta3.Page
{
    public partial class UserList : Page
    {
        private void InitControllers()
        {
            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                int nusers = Beta3Context.Context.User.Count();

                switch (EventArgs.KeyEvent.Key)
                {
                    case Key.Esc:
                    case Key.End:
                        this.RequestStop();
                        break;
                    case Key.PageUp:
                        if (page > 0)
                        {
                            page--;

                            users.Text = UsersListString();
                            users.CanFocus = true;
                            users.Width = width;
                            users.Height = Height;
                            users.X = this.Bounds.Right / 2 - width / 2;
                            users.Redraw(users.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                    case Key.PageDown:
                        if (page < Math.Ceiling((float)nusers / perPage) - 1)
                        {
                            page++;

                            users.Text = UsersListString();
                            users.CanFocus = true;
                            users.Width = width;
                            users.Height = Height;
                            users.X = this.Bounds.Right / 2 - width / 2;
                            users.Redraw(users.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                }
            };
        }
    }
}
