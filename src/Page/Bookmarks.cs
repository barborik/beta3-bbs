using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Bookmarks : Page
    {
        private int nbookmarks;
        private List<Entity.Bookmark> bookmarksList;

        public Bookmarks()
        {
            page = 0;
            nbookmarks = Beta3Context.Context.Board.Count();

            bookmarksList = new List<Entity.Bookmark>();

            InitViews();
            InitControllers();
        }
    }
}
