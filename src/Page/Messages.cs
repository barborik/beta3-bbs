using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Messages : Page
    {
        private Entity.User from;

        public Messages(Entity.User from)
        {
            this.from = from;

            InitViews();
            InitControllers();
        }
    }
}
