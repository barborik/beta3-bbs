using Terminal.Gui;

namespace Beta3.Page
{
    public partial class BoardsList : Page
    {
        int nboards;

        public BoardsList()
        {
            page = 0;
            nboards = Beta3Context.Context.Board.Count();
            boardsList = new List<Entity.Board>();

            InitViews();
            InitControllers();
        }
    }
}
