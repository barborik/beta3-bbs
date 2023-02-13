using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Bookmarks : Page
    {
        private void InitControllers()
        {
            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                int nbookmarks = Beta3Context.Context.User.Count();

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

                            bookmarks.Text = BookmarksListString();
                            bookmarks.CanFocus = true;
                            bookmarks.Width = width;
                            bookmarks.Height = Height;
                            bookmarks.X = this.Bounds.Right / 2 - width / 2;
                            bookmarks.Redraw(bookmarks.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                    case Key.PageDown:
                        if (page < Math.Ceiling((float)nbookmarks / perPage) - 1)
                        {
                            page++;

                            bookmarks.Text = BookmarksListString();
                            bookmarks.CanFocus = true;
                            bookmarks.Width = width;
                            bookmarks.Height = Height;
                            bookmarks.X = this.Bounds.Right / 2 - width / 2;
                            bookmarks.Redraw(bookmarks.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                }

                int index = ((char)EventArgs.KeyEvent.Key) - 'A';
                if (index >= 0 && index < bookmarksList.Count)
                {
                    Entity.Bookmark bookmark = bookmarksList[index];

                    if (bookmark.BoardID != null)
                    {
                        Application.Run(new Board(bookmark.Board));
                    }
                    else
                    {
                        Application.Run(new Thread(bookmark.Thread));
                    }
                }
            };
        }
    }
}
