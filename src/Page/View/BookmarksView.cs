using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Bookmarks : Page
    {
        private View prev;
        private View next;
        private View bookmarks;

        private int page = 0, width, height, perPage;

        private string BookmarksListString()
        {
            char c = 'A';
            string text = "";

            width = 0;
            height = 0;

            bookmarksList.Clear();

            perPage = Application.Top.Bounds.Bottom - 8;
            if (perPage > 'Z' - 'A' + 1)
            {
                perPage = 'Z' - 'A' + 1;
            }

            bookmarks.RemoveAll();

            for (int i = 0; i < perPage; i++)
            {
                Entity.Bookmark bookmark;
                try
                {
                    bookmark = Beta3Context.Context.Bookmark.Where(b => b.UserID == Home.user.ID).ToList()[page * perPage + i];
                }
                catch
                {
                    continue;
                }

                string listing;
                if (bookmark.BoardID != null)
                {
                    listing = String.Format("[{0}] Board - {1}\n", c, Beta3Context.Context.Board.Where(b => b.ID == bookmark.BoardID).First().Name);
                }
                else
                {
                    listing = String.Format("[{0}] Thread - {1}\n", c, Beta3Context.Context.Thread.Where(t => t.ID == bookmark.ThreadID).First().Title);
                }

                text += listing;

                bookmarksList.Add(bookmark);

                View select = new View()
                {
                    Text = c.ToString(),
                    X = 1,
                    Y = i,
                    Width = 1,
                    Height = 1,
                    ColorScheme = redOnBlack,
                };
                bookmarks.Add(select);

                if (listing.Length > width)
                {
                    width = listing.Length;
                }
                height++;
                c++;
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

            bookmarks = new View()
            {
                Y = Pos.Center(),
                TextAlignment = TextAlignment.Left,
                CanFocus = true,
                ColorScheme = whiteOnBlack,
            };
            bookmarks.Text = BookmarksListString();
            bookmarks.X = Pos.Center() - width / 2;
            bookmarks.Width = width;
            bookmarks.Height = height;

            this.Add(next);
            this.Add(prev);
            this.Add(bookmarks);
        }
    }
}
