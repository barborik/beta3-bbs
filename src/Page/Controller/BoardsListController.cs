using Terminal.Gui;

namespace Beta3.Page
{
    public partial class BoardsList : Page
    {
        private void InitControllers()
        {
            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                nboards = Beta3Context.Context.Board.Count();

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

                            boards.Text = BoardsListString();
                            boards.Redraw(boards.Bounds);
                            boards.Width = width;
                            boards.Height = Height;
                        }
                        break;
                    case Key.PageDown:
                        if (page < Math.Ceiling((float)nboards / perPage) - 1)
                        {
                            page++;

                            boards.Text = BoardsListString();
                            boards.Redraw(boards.Bounds);
                            boards.Width = width;
                            boards.Height = Height;
                        }
                        break;
                }

                int index = ((char)EventArgs.KeyEvent.Key) - 'A';
                if (index >= 0 && index < boardsList.Count)
                {
                    Application.Run(new Board(boardsList[index]));
                }
            };
        }
    }
}
