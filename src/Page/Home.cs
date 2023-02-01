using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Home : Page
    {
        public static Entity.User user;

        public Home(Entity.User user)
        {
            Home.user = user;

            InitViews();
            InitControllers();
        }
    }
}
