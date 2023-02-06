using Terminal.Gui;

namespace Beta3.Page
{
    public partial class Messages : Page
    {
        private void SendButtonController()
        {
            if (messageField.Text.IsEmpty)
            {
                return;
            }

            Entity.Message message = new Entity.Message()
            {
                SenderID = Home.user.ID,
                ReceiverID = this.from.ID,
                Content = (string)messageField.Text,
                Sent = DateTime.Now,
            };

            Beta3Context.Context.Message.Add(message);
            Beta3Context.Context.SaveChanges();
        }

        private void InitControllers()
        {
            sendButton.Clicked += SendButtonController;

            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                switch (EventArgs.KeyEvent.Key)
                {
                    case Key.Esc:
                    case Key.End:
                        this.RequestStop();
                        break;
                }
            };
        }
    }
}
