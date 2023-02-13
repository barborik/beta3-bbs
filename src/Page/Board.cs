using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Board : Page
    {
        private int nthreads;
        private Entity.Board board;

        public Board(Entity.Board board)
        {
            page = 0;
            nthreads = Beta3Context.Context.Board.Count();
            this.board = board;

            this.threadsList = new List<Entity.Thread>();

            InitViews();
            InitControllers();
        }
    }
}
