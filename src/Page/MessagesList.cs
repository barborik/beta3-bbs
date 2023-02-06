using Terminal.Gui;

namespace Beta3.Page
{
    public partial class MessagesList : Page
    {
        List<Entity.User> contactsList;

        public MessagesList()
        {
            contactsList = new List<Entity.User>();

            InitViews();
            InitControllers();
        }
    }
}
