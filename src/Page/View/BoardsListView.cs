using Terminal.Gui;

namespace Beta3.Page
{
    public partial class BoardsList : Page
    {
        private View prev;
        private View next;
        private View boards;

        private int page;
        private List<Entity.Board> boardsList;

        private int width, height, perPage;

        private string BoardsListString()
        {
            char c = 'A';
            string text = "";

            width = 0;
            height = 0;

            boardsList.Clear();

            perPage = Application.Top.Bounds.Bottom - 8;
            if (perPage > 'Z' - 'A' + 1)
            {
                perPage = 'Z' - 'A' + 1;
            }

            boards.RemoveAll();

            for (int i = 0; i < perPage; i++)
            {
                Entity.Board board;
                try
                {
                    board = Beta3Context.Context.Board.ToList()[page * perPage + i];
                }
                catch
                {
                    continue;
                }

                string listing = String.Format("[{0}] {1}\n", c, board.Name);
                text += listing;

                boardsList.Add(board);

                View select = new View()
                {
                    Text = c.ToString(),
                    X = 1,
                    Y = i,
                    Width = 1,
                    Height = 1,
                    ColorScheme = redOnBlack,
                };
                boards.Add(select);

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
                Y = 0,
                Width = 12,
                Height = 2,
                Text = "↑\n[Page Up]",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            next = new View()
            {
                X = Pos.Center(),
                Y = Pos.Bottom(this) - 4,
                Width = 12,
                Height = 2,
                Text = "[Page Down]\n↓",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            boards = new View()
            {
                X = Pos.Center(),
                Y = Pos.Center(),
                Width = width,
                Height = height,
                TextAlignment = TextAlignment.Left,
            };
            boards.Text = BoardsListString();
            boards.Width = width;
            boards.Height = height;

            this.Add(prev);
            this.Add(next);
            this.Add(boards);
        }
    }
}
