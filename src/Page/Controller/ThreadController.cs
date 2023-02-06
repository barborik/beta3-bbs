using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Thread : Page
    {
        private void PostButtonController()
        {
            if (postField.Text.IsEmpty)
            {
                return;
            }

            Entity.Post post = new Entity.Post()
            {
                UserID = Home.user.ID,
                ThreadID = this.thread.ID,
                Content = (string)postField.Text,
                Created = DateTime.Now,
            };

            Beta3Context.Context.Post.Add(post);
            Beta3Context.Context.SaveChanges();
        }

        private void InitControllers()
        {
            postButton.Clicked += PostButtonController;

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
