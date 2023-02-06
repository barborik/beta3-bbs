using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Thread : Page
    {
        Entity.Thread thread;

        public Thread(Entity.Thread thread)
        {
            this.thread = thread;

            InitViews();
            InitControllers();
        }
    }
}
