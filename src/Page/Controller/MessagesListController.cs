using Terminal.Gui;

namespace Beta3.Page
{
    public partial class MessagesList : Page
    {
        private void sendButtonController()
        {
            Entity.User to;

            try
            {
                to = Beta3Context.Context.User.Where(u => u.Username == (string)unameField.Text).First();
            }
            catch
            {
                MessageBox.ErrorQuery("", "User does not exist", "OK");
                return;
            }

            Entity.Message message = new Entity.Message()
            {
                SenderID = Home.user.ID,
                ReceiverID = to.ID,
                Content = (string)messageField.Text,
                Sent = DateTime.Now,
            };

            Beta3Context.Context.Message.Add(message);
            Beta3Context.Context.SaveChanges();
        }

        private void InitControllers()
        {
            sendButton.Clicked += sendButtonController;

            KeyDown += (EventArgs) =>
            {
                if (!this.IsCurrentTop)
                {
                    return;
                }

                int ncontacts = Beta3Context.Context.User.Count();

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

                            contacts.Text = ContactsListString();
                            contacts.CanFocus = true;
                            contacts.Width = width;
                            contacts.Height = Height;
                            contacts.X = this.Bounds.Right / 2 - width / 2;
                            contacts.Redraw(contacts.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                    case Key.PageDown:
                        if (page < Math.Ceiling((float)ncontacts / perPage) - 1)
                        {
                            page++;

                            contacts.Text = ContactsListString();
                            contacts.CanFocus = true;
                            contacts.Width = width;
                            contacts.Height = Height;
                            contacts.X = this.Bounds.Right / 2 - width / 2;
                            contacts.Redraw(contacts.Bounds);
                            this.Redraw(this.Bounds);
                        }
                        break;
                }

                int index = ((char)EventArgs.KeyEvent.Key) - 'A';
                if (index >= 0 && index < contactsList.Count && contacts.HasFocus)
                {
                    Application.Run(new Messages(contactsList[index]));
                }
            };
        }
    }
}
