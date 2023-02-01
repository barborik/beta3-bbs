using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Board : Page
    {
        Entity.Board board;

        public Board(Entity.Board board)
        {
            this.board = board;

            InitViews();
            InitControllers();
        }
    }
}
