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

            this.RequestStop();
            Application.Run(new Thread(thread));
        }

        private void BoardBookmark()
        {
            if (removeBoardBookmark)
            {
                Beta3Context.Context.Bookmark.Remove(Beta3Context.Context.Bookmark.Where(b => b.BoardID == thread.BoardID && b.UserID == Home.user.ID).First());
            }
            else
            {
                Entity.Bookmark bookmark = new Entity.Bookmark()
                {
                    UserID = Home.user.ID,
                    BoardID = thread.BoardID,
                };

                Beta3Context.Context.Bookmark.Add(bookmark);
            }

            Beta3Context.Context.SaveChanges();

            this.RequestStop();
            Application.Run(new Thread(thread));
        }

        private void ThreadBookmark()
        {
            if (removeThreadBookmark)
            {
                Beta3Context.Context.Bookmark.Remove(Beta3Context.Context.Bookmark.Where(b => b.ThreadID == thread.ID && b.UserID == Home.user.ID).First());
            }
            else
            {
                Entity.Bookmark bookmark = new Entity.Bookmark()
                {
                    UserID = Home.user.ID,
                    ThreadID = thread.ID,
                };

                Beta3Context.Context.Bookmark.Add(bookmark);
            }

            Beta3Context.Context.SaveChanges();

            this.RequestStop();
            Application.Run(new Thread(thread));
        }

        private void InitControllers()
        {
            postButton.Clicked += PostButtonController;
            bookmarkBoard.Clicked += BoardBookmark;
            bookmarkThread.Clicked += ThreadBookmark;

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
