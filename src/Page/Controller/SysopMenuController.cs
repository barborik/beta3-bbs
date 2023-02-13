using Terminal.Gui;

namespace Beta3.Page
{
    public partial class SysopMenu : Page
    {
        private void AddBan()
        {
            try
            {
                Entity.Ban ban = new Entity.Ban()
                {
                    UserID = Home.user.ID,
                    Reason = (string)banReason.Text,
                    Start = DateTime.Now,
                    End = banEnd.Date,
                };

                Beta3Context.Context.Ban.Add(ban);
                Beta3Context.Context.SaveChanges();
            }
            catch { }

            this.RequestStop();
            Application.Run(new SysopMenu());
        }

        private void AddMod()
        {
            try
            {
                Entity.Moderator mod = new Entity.Moderator()
                {
                    UserID = Beta3Context.Context.User.Where(u => u.Username == (string)promoteUserField.Text).First().ID,
                    BoardID = Beta3Context.Context.Board.Where(b => b.Name == (string)promoteBoardField.Text).First().ID,
                };

                Beta3Context.Context.Moderator.Add(mod);
                Beta3Context.Context.SaveChanges();
            }
            catch
            { }

            this.RequestStop();
            Application.Run(new SysopMenu());
        }

        private void InitControllers()
        {
            banButton.Clicked += AddBan;
            promoteButton.Clicked += AddMod;

            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                switch (EventArgs.KeyEvent.Key)
                {
                    case Key.Esc:
                    case Key.End:
                        this.RequestStop();
                        break;
                }
            };
        }
    }
}
