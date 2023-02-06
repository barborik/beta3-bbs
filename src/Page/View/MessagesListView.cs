using Terminal.Gui;

namespace Beta3.Page
{
    public partial class MessagesList : Page
    {
        private View messageForm;
        private Label unameLabel;
        private Label messageLabel;
        private TextField unameField;
        private TextView messageField;
        private Button sendButton;

        private View prev;
        private View next;
        private View contacts;

        private int page = 0, width, height, perPage;

        private string ContactsListString()
        {
            char c = 'A';
            string text = "";

            width = 0;
            height = 0;

            contactsList.Clear();

            perPage = Application.Top.Bounds.Bottom - 22;
            if (perPage > 'Z' - 'A' + 1)
            {
                perPage = 'Z' - 'A' + 1;
            }

            contacts.RemoveAll();

            for (int i = 0; i < perPage; i++)
            {
                Entity.User user;
                try
                {
                    user = Beta3Context.Context.User.ToList()[page * perPage + i];
                }
                catch
                {
                    continue;
                }

                string listing = String.Format("[{0}] {1}\n", c, user.Username);
                text += listing;

                contactsList.Add(user);

                View select = new View()
                {
                    Text = c.ToString(),
                    X = 1,
                    Y = i,
                    Width = 1,
                    Height = 1,
                    ColorScheme = redOnBlack,
                };
                contacts.Add(select);

                if (listing.Length > width)
                {
                    width = listing.Length;
                }
                height++;
                c++;
            }

            return text;
        }

        private void InitViews()
        {
            // LIST
            prev = new View()
            {
                X = Pos.Center() - 16,
                Y = Pos.Bottom(this) - 4,
                Width = 16,
                Height = 2,
                Text = "↑ [Page Up]",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            next = new View()
            {
                X = Pos.Center() + 0,
                Y = Pos.Bottom(this) - 4,
                Width = 16,
                Height = 2,
                Text = "[Page Down] ↓",
                ColorScheme = whiteOnBlack,
                TextAlignment = TextAlignment.Centered,
            };

            contacts = new View()
            {
                Y = 16,
                TextAlignment = TextAlignment.Left,
                CanFocus = true,
                ColorScheme = whiteOnBlack,
            };
            contacts.Text = ContactsListString();
            contacts.X = Pos.Center() - width / 2;
            contacts.Width = width;
            contacts.Height = height;

            this.Add(next);
            this.Add(prev);
            this.Add(contacts);

            // FORM
            messageForm = new View()
            {
                X = Pos.Center(),
                Y = 1,
                Width = 46,
                Height = 13,
                Border = new Border()
                {
                    Title = "Send a New Message",
                    BorderStyle = BorderStyle.Single,
                },
                ColorScheme = whiteOnBlack,
            };

            unameLabel = new Label()
            {
                X = 3,
                Y = 1,
                Text = "To",
            };

            messageLabel = new Label()
            {
                X = 3,
                Y = 4,
                Text = "Content",
            };

            unameField = new TextField()
            {
                X = 3,
                Y = 2,
                Width = 40,
                Height = 1,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
            };

            messageField = new TextView()
            {
                X = 3,
                Y = 5,
                Width = 40,
                Height = 6,
                ColorScheme = new ColorScheme()
                {
                    Normal = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                    Focus = new Terminal.Gui.Attribute(Color.White, Color.Blue),
                },
                WordWrap = true,
                AllowsTab = false,
            };

            sendButton = new Button()
            {
                X = 3,
                Y = 12,
                Width = 4,
                Height = 1,
                Text = "Send",
                ColorScheme = buttonScheme,
            };

            this.Add(messageForm);
            messageForm.Add(unameLabel);
            messageForm.Add(unameField);
            messageForm.Add(messageLabel);
            messageForm.Add(messageField);
            messageForm.Add(sendButton);
        }
    }
}
