using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Board : Page
    {
        private void postButtonController()
        {
            if (titleField.Text.IsEmpty || contentField.Text.IsEmpty)
            {
                return;
            }

            Entity.Thread thread = new Entity.Thread()
            {
                BoardID = this.board.ID,
                Title = (string)this.titleField.Text,
            };

            Beta3Context.Context.Thread.Add(thread);
            Beta3Context.Context.SaveChanges();

            Entity.Post post = new Entity.Post()
            {
                UserID = Home.user.ID,
                ThreadID = thread.ID,
                Content = (string)contentField.Text,
                Created = DateTime.Now,
            };

            Beta3Context.Context.Post.Add(post);
            Beta3Context.Context.SaveChanges();
        }

        private void InitControllers()
        {
            postButton.Clicked += postButtonController;

            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                nthreads = Beta3Context.Context.Board.Count();

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

                            threads.Text = ThreadsListString();
                            threads.CanFocus = true;
                            threads.Width = width;
                            threads.Height = Height;
                            threads.X = this.Bounds.Right / 2 - width / 2;
                            threads.Redraw(threads.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                    case Key.PageDown:
                        if (page < Math.Ceiling((float)nthreads / perPage) - 1)
                        {
                            page++;

                            threads.Text = ThreadsListString();
                            threads.CanFocus = true;
                            threads.Width = width;
                            threads.Height = Height;
                            threads.X = this.Bounds.Right / 2 - width / 2;
                            threads.Redraw(threads.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                }

                int index = ((char)EventArgs.KeyEvent.Key) - 'A';
                if (index >= 0 && index < threadsList.Count && threads.HasFocus)
                {
                    Application.Run(new Thread(threadsList[index]));
                }
            };
        }
    }
}
